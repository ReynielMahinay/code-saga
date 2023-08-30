using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManger : MonoBehaviour
{   
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;
    

    private void Start()
    {
        if(!DataPersistentManger.instance.HasGameData())
            {
            continueGameButton.interactable = false;

            }
    }   
    public void StartGame(){
    
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();

    }

    public void LoadGame(){
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();

    }

    public void ExitGame(){

        Application.Quit();
    }

    private void DisableMenuButton(){
        newGameButton.interactable = false;
    }

    public void ActivateMenu(){
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu(){
        this.gameObject.SetActive(false);
    }



}
