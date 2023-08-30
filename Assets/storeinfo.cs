using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeinfo : MonoBehaviour
{
    public GameObject storeinf;
    public bool playerIsClose;
    void Update(){
    if(playerIsClose)   
    {
        storeinf.SetActive(true);
    }
    else
    {
       // storeinf.SetActive(false);
    }
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            
            
       
        
        }

    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            
            storeinf.SetActive(false);
            Destroy(gameObject);
            
            
        }

    }
}
