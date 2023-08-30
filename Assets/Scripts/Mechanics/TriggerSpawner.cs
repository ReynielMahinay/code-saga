using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public Spawner spawner;
    public Spawner spawner1;
    public Spawner spawner2;

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player")){
            spawner.SpawnObject();
            spawner1.SpawnObject();
            spawner2.SpawnObject();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        Destroy(gameObject);
    }

    
}
