using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySounds : MonoBehaviour
{
    public AudioSource inventorySound;

    public void playThisSound(){
        inventorySound.Play();
    }
}
