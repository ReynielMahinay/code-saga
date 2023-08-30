using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{   
    public AudioSource wrongSound;

    public void PlayThisSound(){
        wrongSound.Play();
    }
}   
