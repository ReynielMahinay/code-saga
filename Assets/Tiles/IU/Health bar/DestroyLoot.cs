using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyLoot : MonoBehaviour
{
    public int value;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            
            Destroy(transform.parent.gameObject);
            CrystalCounter.instance.AddCrystal(value);
            
        }
    }

    
}
