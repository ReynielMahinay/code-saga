using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistentManger : MonoBehaviour
{   
    [Header("Debugging")]
    [SerializeField] private bool disableDataPersistentManager =  false;
    [SerializeField] private bool InitializeDataIfNull = false;
    [SerializeField] private bool overrideSelecetedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";
    

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<IDataPersistent> dataPersistentObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId ="";

    public static DataPersistentManger instance{get; private set;}

    private void Awake() {

    if(instance != null){

            Debug.Log("Found more than one Data Persistence Manager in the scene");
            Destroy(this.gameObject);
            return;
        } 
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        if(disableDataPersistentManager){
            Debug.Log("Data Persistent is currently disable");
        }

        //%userprofile%\AppData\LocalLow file path
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
   
        InitializedSelectedProfileId();
    }

    private void OnEnable() {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable(){

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        this.dataPersistentObjects = FindAllDataPersistentObjects();
        LoadGame();
    }

    public void ChangeSelectedProfileId(string newProfileId){
        //update the profile to use for saving and loading
        this.selectedProfileId = newProfileId;

        LoadGame();
    }

    public void DeleteProfileData(string profileId){
        //delete the data for this profile id
        dataHandler.Delete(profileId);
        //initialize the selected profile id
        InitializedSelectedProfileId();
        //reload the game so to match the new data of selected profile id
        LoadGame();
    }

    private void InitializedSelectedProfileId(){

        if(overrideSelecetedProfileId){
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Override selected profile id with the test id:" + testSelectedProfileId); 
        }
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){

        //for disabling sava data for debugging;
        if(disableDataPersistentManager){
            return;
        }

        this.gameData = dataHandler.Load(selectedProfileId);

        //Start a new game if even there is no data for playing specific scene to debug
        if(this.gameData == null && InitializeDataIfNull)
        {
            NewGame();
        }

        //if there is no data to load, play the NewGame()
        if(this.gameData == null){
            Debug.Log("No data was found. Initializing data to defaults");
            return;
        }

        //add the loaded data to all other scripts that need it
        foreach (IDataPersistent dataPersistentObj in dataPersistentObjects)
        {
            dataPersistentObj.LoadData(gameData);
            Debug.Log("data loaded");

        }

       
        
    } 

    public void SaveGame(){
        
         //for disabling sava data for debugging;
        if(disableDataPersistentManager){
            return;
        }

        if(this.gameData == null){
            return;
        }
        //send the data to other scripts so they can update it
        foreach (IDataPersistent dataPersistentObj in dataPersistentObjects)
        {   
           
            dataPersistentObj.SaveData(gameData);
        }

        Scene scene = SceneManager.GetActiveScene();
        if (!scene.name.Equals("Menu"))
        {
            gameData.currentSceneName = scene.name;
        }
            dataHandler.Save(gameData, selectedProfileId);  
    }

    public string GetSavedSceneName() 
    {
        // error out and return null if we don't have any game data yet
        if (gameData == null) 
        {
            Debug.LogError("Tried to get scene name but data was null.");
            return null;
        }
             // otherwise, return that value from our data
             Debug.Log("load scene");
             return gameData.currentSceneName;
    }

    private List<IDataPersistent> FindAllDataPersistentObjects(){

    IEnumerable<IDataPersistent> dataPersistentObjects = FindObjectsOfType<MonoBehaviour>()
    .OfType<IDataPersistent>();

    return new List<IDataPersistent>(dataPersistentObjects);
    }

    public bool HasGameData(){
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData(){

        return dataHandler.LoadAllProfiles();
    }

     
}
