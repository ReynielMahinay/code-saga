using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{     
    public Animator portal;
    public AudioSource activated;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Save Game");
            DataPersistentManger.instance.SaveGame();
            activated.Play();
            portal.SetTrigger("activate");
            Debug.Log("Position" + transform.position);
        }
    }
}
