using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour
{   
    private PlayerControls playerControls;
    private InputAction map;
    private bool mapIsOpen;
    public GameObject mapPanel;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        mapIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable() {

            map = playerControls.Menu.Map;
            map.Enable();

            map.performed += mapController;
    }

    private void OnDisable() {

            map.Disable();
    }

    void mapController(InputAction.CallbackContext context){

        mapIsOpen = !mapIsOpen;
        
        if(mapIsOpen){
            ActiveMap();
        }else{
            DeactiveMap();
        }
    }

    void ActiveMap(){
        Debug.Log("Open map");
            mapPanel.SetActive(true);
            mapIsOpen = true;
    }
    void DeactiveMap(){
            Debug.Log("Close map");
            mapPanel.SetActive(false);
            mapIsOpen = false;
    }
}
