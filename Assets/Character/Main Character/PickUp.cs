using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject sword;

    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            sword.SetActive(true);
            Debug.Log("PIckup");
        }
    
    

    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            
            
        }

    }
}
