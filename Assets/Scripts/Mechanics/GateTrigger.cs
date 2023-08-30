using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GateTrigger : MonoBehaviour
{   
    public GameObject gate;
    public GameObject dialoguePanel;

    public static bool onDialog;
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {   
           gate.SetActive(true);
           dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {        
             gate.SetActive(true);
             dialoguePanel.SetActive(false);
             Destroy(gameObject);
        }
    }
}
