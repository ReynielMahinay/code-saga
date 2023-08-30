using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDataPersistent
{
    public int maxHealth = 6;
    public int healthCount = 6;

    private float transitionTime = 3f; 

    public Image[] HealthBar;
    public Sprite fullHealthBar;
    public Sprite emptyHealthBar;

    public GameObject deathScene;
    public Animator transition;

    public AudioSource deathSfx;

    [Header("Hit Effect")]
    [SerializeField]private flashEffectMMC HealEffect;
    [SerializeField]private Color color;

    

    void Update(){

        if(healthCount > maxHealth){
            healthCount = maxHealth;
            
        }

            for (int i = 0; i < HealthBar.Length; i++){

                if(i < healthCount){
                    HealthBar[i].sprite = fullHealthBar;
                } else{
                    HealthBar[i].sprite = emptyHealthBar;
                }

                if(i < maxHealth){
                    HealthBar[i].enabled = true;
                } else{
                    HealthBar[i].enabled = false;
                }
            }
    }
    

    public void UpdateHealth(int mod){
        healthCount += mod;
        HealEffect.Flash(color);
        
        if(healthCount > maxHealth){
            healthCount = maxHealth;
        }else if(healthCount <= 0){
                healthCount = 0;
                Respawn();
        }
    }

    public void LoadData(GameData data){
        this.healthCount = data.healthCount;
    }

    public void SaveData(GameData data)
    {
    data.healthCount = this.healthCount;
    }

    public void Respawn(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));   
    }

    IEnumerator LoadLevel(int levelIndex){
        deathScene.SetActive(true);
        transition.Play("death_start");
        deathSfx.enabled = true;
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
}
