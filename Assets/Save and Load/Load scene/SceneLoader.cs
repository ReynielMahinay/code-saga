using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    public AudioSource teleport;
    public Animator transition;
    public float transitionTime = 1f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject collisionGameObject = other.gameObject;

        if(collisionGameObject.tag == "Player"){
            teleport.enabled = true;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
