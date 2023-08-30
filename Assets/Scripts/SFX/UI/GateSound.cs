using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSound : MonoBehaviour
{
    public AudioSource gateSound;

    public void PlayThisSound(){
        gateSound.Play();
    }
}
