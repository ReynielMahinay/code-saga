using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControls : MonoBehaviour
{   
    public GameObject controls;
    
    public GameObject bag;

    
      private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {   
            controls.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {        
            controls.SetActive(false);
             bag.SetActive(true);
            
            Destroy(gameObject);
        }
    }

    public void spaceClose(){
        if (Input.GetMouseButtonDown(0)){
            controls.SetActive(false);
            
            Debug.Log("click");
            Destroy(gameObject);
        }
    }
}
