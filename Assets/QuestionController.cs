using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
 public GameObject qpanel;
 public static bool onPanel;
 public bool playerIsClose;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            qpanel.SetActive(true);
            ActivatePanel();
        }
        else{
           
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
            playerIsClose = false;
            DeactivatePanel();
        }

    }

    void ActivatePanel(){
        qpanel.SetActive(true);
        onPanel = true;
    }

    void DeactivatePanel(){
        qpanel.SetActive(false);
        onPanel = false;
    }
}
