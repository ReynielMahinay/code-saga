using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{    
    public GameObject controls;
    
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
            Destroy(gameObject);
        }
    }

}
