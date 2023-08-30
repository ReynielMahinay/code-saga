using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "Aarhus";

    private readonly string backupExtension = ".bak";

    //file path of the save data
   // %userprofile%\AppData\LocalLow\ 

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption){

        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;

        //use to encrypt
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileId, bool allowRestoreFromBackup = true){

        //use path.Combine for different os running the game cause there are different path separators
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath)){

            try{
                //to load the serailized data from the json file
                string dataToload = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using(StreamReader reader = new StreamReader(stream)){
                        dataToload = reader.ReadToEnd();
                    }
                }

                if(useEncryption){
                    dataToload = EncryptDecrypt(dataToload);
                }
                //desrailized or translate from json to c#
                loadedData = JsonUtility.FromJson<GameData>(dataToload);
            }
            catch(Exception e){

                if(allowRestoreFromBackup){
                    Debug.LogWarning("loading data failed. Attempting to roll back \n" + e );
                    
                    bool rollbackSuccess = AttemptRollback(fullPath);
                    if(rollbackSuccess){
                        loadedData = Load(profileId, false);
                    }
                }else{
                    Debug.LogError("Error happen when trying to load the save data" 
                    + fullPath + " and backup did not work. \n" + e);
                }
            }
        }

        return loadedData;
    }


    public void Save(GameData data, string profileId){
        
        //use path.Combine for different os running the game cause there are different path separators
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        //getting path of save data
        string backupFilePath = fullPath + backupExtension; 
        try{

            //create the directory the file will be written to it if doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serailize the game data to json file format
            string dataToStore = JsonUtility.ToJson(data, true);


            if(useEncryption){
                dataToStore = EncryptDecrypt(dataToStore);
            }
            //write the save serailize data to the file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create)){
                
                using(StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
            //verify the newly save file that loaded sucessfuly
            GameData verifiedGameData = Load(profileId);
            //if the data verified, create a back up
            if(verifiedGameData != null){
                File.Copy(fullPath, backupFilePath, true);  
            }
            //the result is null
            else{
                throw new Exception("save file cannot verified and the backup could not be created");
            }
        }
        catch(Exception e){
            Debug.LogError("Error occured when trying to save data to file" + fullPath + "\n" + e);
        }
    }

    public void Delete(string profileId){

        //if the profileId is null, return
        if(profileId == null){
            return;
        }

        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        try{
            // to make sure file exist at this path before deleting the directory
            if(File.Exists(fullPath)){
                //delete the profile folder and everything withint it
                Directory.Delete(Path.GetDirectoryName(fullPath), true);
            }
            else{
                Debug.LogWarning("Tried to delete profile data, but data was not found at path" + fullPath);
            }
        }
        catch(Exception e){
            Debug.LogError("Failed to delete profile data for profileId: " 
            + profileId + "at path" + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles(){

        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        //loop over all diretory namesin the data directory path
        foreach(DirectoryInfo dirInfo in dirInfos){

            string profileId = dirInfo.Name;
            // defensive programming - check if the data file exists
            // if it doesn't, then this folder isn't a profile and should be skipped
            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
            if (!File.Exists(fullPath))
            {
                    Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: "
                    + profileId);
                    continue;
            }
            // Load the game data for this profile and put it in the dictionary
            GameData profileData = Load(profileId);

            if (profileData != null)
            {
                profileDictionary.Add(profileId, profileData);
            }
            else
            {
                Debug.LogError ("Tried to load profile but something went wrong. ProfileId : " + profileId );
                }

        }

        return profileDictionary;
    }

    //to encrypt the json file called XOR method
    private string EncryptDecrypt(string data){

        string modifiedData = "";
        for(int i = 0; i < data.Length; i++){

            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        
        return modifiedData;
    }

    //for roll back the data from backup file
    private bool AttemptRollback(string fullPath){
        bool success = false;
        string backupFilePath = fullPath + backupExtension;
        try{
            //if the file exists, try to rol back the save data from backupfile to orignial file
            if(File.Exists(backupFilePath)){
                File.Copy(backupFilePath, fullPath, true);
                success = true;
                Debug.LogWarning("rollback has done" + backupFilePath);
            }
            //if there is no backup file and there is nothing to roll back
            else{
                throw new Exception("Tried to roll back data save data but there is no backup file");
            }
        }
        catch(Exception e){
            Debug.LogError("Error happen when trying to roll back the save data" +
            backupFilePath + "\n" + e);
        }

        return success;
    }
}
