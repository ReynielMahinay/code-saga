using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GrimHP : MonoBehaviour
{   
    [Header("HealthBar")]
    [SerializeField]
    private int currentHealth, maxHealth;
    public Slider healthBar;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject hpBar;

    [Header("Background Music")]
    public GameObject oldEntrace;
    public GameObject NewEntrance;

    [Header("Timer")]
    public GameObject TimerText;
    public GameObject TimerManager;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    public GameObject gateKeeper;
    public Animator anim;

    public GameObject DropLoot;
    public static bool canSummmon;
    public static bool rageMode;

    public GameObject lootDrop;
    public GameObject lootDrop2;
    public GameObject lootDrop3;
    public GameObject boss;


    public int delay = 7;

    GameObject _dropLootTracker;

    private int dropNumber = 500;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        
        isDead = false;
    }

    void Start(){
        _dropLootTracker = GameObject.FindGameObjectWithTag("DropLootTracker");
        canSummmon = false;
        rageMode = false;

    }

    private void Update() {
        RageMode();
        death();
        healthBar.value = currentHealth;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;

        
        if (currentHealth > 0)
        {   
            if(currentHealth <= 70){
                fire1.SetActive(true);
            }

            if(currentHealth <= 65){
                fire2.SetActive(true);
                fire3.SetActive(true);
            }
            if(currentHealth == 49)
            {
                lootDrop.SetActive(true);
                lootDrop2.SetActive(true);
                lootDrop3.SetActive(true);
                lootDrop.transform.position = boss.transform.position;
                lootDrop2.transform.position = boss.transform.position;
                lootDrop3.transform.position = boss.transform.position;
            }
            if(currentHealth <= 50){
                    rageMode = true;
                    Debug.Log("rage");
                    fire4.SetActive(true);
                    fire5.SetActive(true);
                    fire6.SetActive(true);
            }

            OnHitWithReference?.Invoke(sender);
        }


        else
        {
            OnDeathWithReference?.Invoke(sender);
            anim.SetTrigger("died");
            gateKeeper.SetActive(true);
            hpBar.SetActive(false);
            oldEntrace.SetActive(true);
            NewEntrance.SetActive(false);
            TimerManager.SetActive(false);
            TimerText.SetActive(false);
            
            for (var i = 0; i < dropNumber / 50; i++)
            {
                var go = Instantiate(DropLoot, transform.position + new Vector3(0, Random.Range(0,3)), Quaternion.identity);
            go.GetComponent<MosnterDrop>().Target = _dropLootTracker.transform;
            }

            isDead = true; 
        }
    }

    public void RageMode(){
        if(rageMode){
            anim.SetTrigger("rage");
            Debug.Log("actiivateeeee");
        }
    }
    
    public void death(){
        if(isDead){
            Destroy(gameObject, delay);
        }
    }
}
