using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatetrigger : MonoBehaviour
{
    public GameObject gateway;
    public GameObject gate;
    public GameObject Qmaster;


    public void OnTriggerExit2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            gateway.SetActive(true);
            gate.SetActive(true);
            
            Destroy(Qmaster);
    }
}
}
