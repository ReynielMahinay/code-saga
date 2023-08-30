using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SceneManger mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;
    
    [Header("Confirmation Popup")]
    [SerializeField] private ConfirmationPopUpMenu confirmationPopUpMenu;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake() {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }   

    public void OnSaveSlotClicked(SaveSlot saveSlot){

        //to prevent double click on button
        DisableMenuButtons();

        //loading game
        if(isLoadingGame){
            //update the  selected profile id to be used for data persistence
            DataPersistentManger.instance. ChangeSelectedProfileId(saveSlot.GetProfileId());
            SaveAndLoad();
        }
        //new game, but the save slot has data
        else if(saveSlot.hasData){
            //calling the Popup menu 
            confirmationPopUpMenu.ActivateMenu(
                "Starting a New Game with this slot will replace currently save data. Are you sure?",
                //function to execute if 'yes' was selected
                () => {
                    //will change the selected save slot or profile id
                    DataPersistentManger.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    //creating new game
                    DataPersistentManger.instance.NewGame();
                    SaveGameAndLoadScene();
                },
                //function to execute if 'no' was selected
                () => {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }

        //starting new game and the save slot is empty
        else{

            //will change the selected save slot or profile id
            DataPersistentManger.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            //creating new game
            DataPersistentManger.instance.NewGame();
            SaveGameAndLoadScene();
        }
    }

    private void SaveAndLoad(){

        DataPersistentManger.instance.SaveGame();
        SceneManager.LoadSceneAsync(DataPersistentManger.instance.GetSavedSceneName());

    }

    private void SaveGameAndLoadScene(){

        //to save game anytime before loading new scene
        DataPersistentManger.instance.SaveGame();
        //load the scene which will in turn save the game because of OnScene UnLoaded() in the DataPersistentManger
        SceneManager.LoadSceneAsync("Intro");
    }
    
    //click function to delete save data 
    public void Onclear(SaveSlot saveSlot){

        DisableMenuButtons();
        confirmationPopUpMenu.ActivateMenu(
            "Are you sure you want to delete this save data?",
            //execute if 'yes' is selected
            () => {
                DataPersistentManger.instance.DeleteProfileData(saveSlot.GetProfileId());
                 ActivateMenu(isLoadingGame); 
            },
            () =>{
                //execute if 'no' is selected
                ActivateMenu(isLoadingGame);
            }
        );

        
    }

    //for back button function
    public void backFunction(){
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame){ 

        //to activate menu
        this.gameObject.SetActive(true);

        //set mode
        this.isLoadingGame = isLoadingGame; 

        //load all of the profiles that exists
        Dictionary<string, GameData> profilesGameData = DataPersistentManger.instance.GetAllProfilesGameData();

        //to make sure the back button is working when activate the menu
        backButton.interactable = true;

        //loop for each save slot in the UI and set the value
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
           
            if(profileData == null && isLoadingGame){

                saveSlot.SetInteractable(false);
            }else{

                saveSlot.SetInteractable(true);
                
            }
        }

    }

    public void DeactivateMenu(){
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons(){

        foreach(SaveSlot saveSlot in saveSlots){
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
