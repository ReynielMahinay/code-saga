using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossTimer : MonoBehaviour
{   
    public Text timerText;

    public float currentTime;
    public bool countDown;
    public GameObject failedScene;
    public Animator transition;
    private float transitionTime = 3f; 
    
    public AudioSource failedSfx;

    public bool hasLimit;
    public float timerLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime: currentTime += Time.deltaTime;

        if(hasLimit &&((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))){

            currentTime = timerLimit;
            SetTimer(currentTime);
            timerText.color = Color.red;
            enabled = false;
        }
       SetTimer(currentTime);
       Respawn();
    }

    private void SetTimer(float timeToDisplay){

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);    
    }

     public void Respawn(){
        if(currentTime == 0){
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));   
        }
        
    }

    IEnumerator LoadLevel(int levelIndex){
        failedScene.SetActive(true);
        transition.Play("death_start");
        failedSfx.enabled = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
