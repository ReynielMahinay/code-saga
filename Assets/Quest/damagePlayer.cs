using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public static damagePlayer Instance;
    [SerializeField] private int damage = 1;
    [SerializeField] private int heal1 = 1;
    [SerializeField] private int heal2 = 2;
    [SerializeField] private int heal3 = 3;
    public GameObject player;

    //healing Effect
    [SerializeField]private flashEffectMMC HealEffect;
    [SerializeField]private Color color;
    
private void Awake(){

    Instance  = this;
}
    public void wrongAsnwer(){
        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
    }
    public void Heal1(){
        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+heal1);
        HealEffect.Flash(color);
    }
    public void Heal2(){
        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+heal2);
        HealEffect.Flash(color);
    }
    public void Heal3(){
        player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+heal3);
        HealEffect.Flash(color);
    }
    
}
