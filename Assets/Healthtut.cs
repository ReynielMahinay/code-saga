using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Healthtut : MonoBehaviour
{[SerializeField]
    private int currentHealth, maxHealth;
   

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    public GameObject DropLoot;

    GameObject _dropLootTracker;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    void Start(){
        _dropLootTracker = GameObject.FindGameObjectWithTag("DropLootTracker");
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
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            gameObject.SetActive(false);
            var go = Instantiate(DropLoot, transform.position, Quaternion.identity);
            go.GetComponent<MosnterDrop>().Target = _dropLootTracker.transform;
            
        }
    }
}
