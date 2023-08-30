using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    
public bool playerIsClose;
public GameObject storepan;
public Animator activ;
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.F) && playerIsClose && !storepan.activeInHierarchy)
         {
            storepan.SetActive(true);
         }
         else{
          

         }
        
        

}
private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            activ.SetTrigger("active");
        }

    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            storepan.SetActive(false);
            activ.SetTrigger("deactive");
        }

    }
}
