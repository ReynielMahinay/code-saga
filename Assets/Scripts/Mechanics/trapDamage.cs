using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDamage : MonoBehaviour
{   
    private Animator anim;
    public AudioSource damageSFX;
    [SerializeField] private int attackDamage = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){ 
                damageSFX.Play();
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                
        }
    }
}
