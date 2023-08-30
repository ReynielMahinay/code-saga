using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    public GameObject hpBar;
    public AudioSource entrace;
    public GameObject oldEntrace;
    public GameObject NewEntrance;

    public GameObject TimerText;
    public GameObject TimerManager;
    [SerializeField]
    private Animator anim;
    public static bool awake;



    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {   
            Panel.SetActive(true);
             
            entrace.Play();
            hpBar.SetActive(true);
            
            oldEntrace.SetActive(false);
            NewEntrance.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {   
            anim.SetTrigger("awake");
            TimerManager.SetActive(true);
            TimerText.SetActive(true); 
            Panel.SetActive(false);
            Destroy(gameObject);
            BossController.bossAwake = true;
        }
    }

    public void spaceClose(){
        if (Input.GetMouseButtonDown(0)){
            Panel.SetActive(false);
        }
    }
}
