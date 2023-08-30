using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{  

    public AudioSource correctSound;

    public void PlayThisSound(){
        correctSound.Play();
    }
}
