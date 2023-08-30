using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RuinProtectorHP : MonoBehaviour
{   
    [Header("HealthBar")]
    [SerializeField]
    private int currentHealth, maxHealth = 50;
    public Slider healthBar;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject hpBar;
    public GameObject boss;

    [Header("Sounds")]
    public GameObject oldEntrace;
    public GameObject NewEntrance;

    public GameObject TimerText;
    public GameObject TimerManager;
    public GameObject lootDrop;
    public GameObject lootDrop2;
    public GameObject lootDrop3;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    public GameObject gateKeeper;
    public Animator anim;
    public Animator animFire;


    public GameObject DropLoot;
    public static bool rageMode;


    public int delay = 7;

    GameObject _dropLootTracker;

    private int dropNumber = 500;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        currentHealth = maxHealth;
        
        isDead = false;
    }

    void Start(){
        _dropLootTracker = GameObject.FindGameObjectWithTag("DropLootTracker");
        rageMode = false;
        currentHealth = maxHealth;
        
    }

    private void Update() {

        RageMode();
        healthBarFill();
        death();
        
        
    }

    void healthBarFill(){

        healthBar.value = currentHealth;
    }

/*    void ColorChanger(){
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));
        healthBar.color = healthColor;
    }
*/
    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;

       
        if (currentHealth > 0)
        {   
            if(currentHealth == 40){
                animFire.SetTrigger("normalFire");
                fire1.SetActive(true);
                
                
            }    

            if(currentHealth == 35){
                fire2.SetActive(true);
                fire3.SetActive(true);
                
                
            }
            if(currentHealth == 30)
            {
                lootDrop.SetActive(true);
                lootDrop2.SetActive(true);
                lootDrop3.SetActive(true);
                lootDrop.transform.position = boss.transform.position;
        lootDrop2.transform.position = boss.transform.position;
        lootDrop3.transform.position = boss.transform.position;
            }
           

            if(currentHealth == 30){
                rageMode = true;
                Debug.Log("rage");
                animFire.SetTrigger("rageFire");
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
        }
    }

    public void death(){
        if(isDead){
            Destroy(gameObject, delay);
        }
    }
}
