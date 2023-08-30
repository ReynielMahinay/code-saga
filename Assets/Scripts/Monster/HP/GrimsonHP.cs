using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GrimsonHP : MonoBehaviour
{
    [Header("HealthBar")]
    [SerializeField]private int currentHealth, maxHealth;
    public Slider healthBar;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject hpBar;
    public GameObject lootDrop;
    public GameObject lootDrop2;
    public GameObject lootDrop3;

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
    public GameObject boss;

    public GameObject DropLoot;
    public static bool canSummmon;
    public static bool rageMode;

     public float delay = 9f;

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
            if(currentHealth <=50){
                fire1.SetActive(true);
            }
            

            if(currentHealth <= 45){
                fire2.SetActive(true);
                fire3.SetActive(true);
            }
            if(currentHealth == 34)
            {
                lootDrop.SetActive(true);
                lootDrop2.SetActive(true);
                lootDrop3.SetActive(true);
                lootDrop.transform.position = boss.transform.position;
                lootDrop2.transform.position = boss.transform.position;
                lootDrop3.transform.position = boss.transform.position;
            }

            if(currentHealth <= 35){
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
            isDead = true;

            for (var i = 0; i < dropNumber / 50; i++)
            {
                var go = Instantiate(DropLoot, transform.position + new Vector3(0, Random.Range(0,3)), Quaternion.identity);
            go.GetComponent<MosnterDrop>().Target = _dropLootTracker.transform;
            }
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

