using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{   
    
    private PlayerControls playerControls;
    private InputAction menu;
    [SerializeField] private GameObject pauseMenu;
    public static bool isPaused;
    public AudioSource pauseSounds;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start() {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable() {

            menu = playerControls.Menu.Pause;
            menu.Enable();

            menu.performed += PauseGame;
    }

    private void OnDisable() {

            menu.Disable();
    }

    void PauseGame(InputAction.CallbackContext context){
        
        isPaused = !isPaused;

        if(isPaused){
            pauseSounds.Play();
            ActivateMenu();
        }

        else{
            pauseSounds.Play();
            DeactivateMenu();
        }
        
    }

    void ActivateMenu(){
        pauseMenu.SetActive(true);
        
        Time.timeScale = 0f;
        isPaused = true;
    }


    void DeactivateMenu(){
        pauseMenu.SetActive(false);
        
        Time.timeScale = 1f;
        isPaused = false;
    }
}
