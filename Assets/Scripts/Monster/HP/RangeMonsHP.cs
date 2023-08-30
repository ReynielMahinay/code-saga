using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeMonsHP : MonoBehaviour
{
    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    public GameObject DropLoot;
    GameObject _dropLootTracker;

    private int dropNumber = 60;


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
            Destroy(gameObject);
            QuestController2.instance.QuestCounter();

            for (var i = 0; i < dropNumber / 30; i++)
            {
                var go = Instantiate(DropLoot, transform.position + new Vector3(0, Random.Range(0,3)), Quaternion.identity);
            go.GetComponent<MosnterDrop>().Target = _dropLootTracker.transform;
            }
            
        }
    }
}
