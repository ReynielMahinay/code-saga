using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{   
    private int time = 6;

    // Update is called once per frame
    void Update()
    {
        gotoMemu();
    }

    public void gotoMemu(){
        if(portalActivate.isReady){
            StartCoroutine(gotoMenu());
        }
    }

    private IEnumerator gotoMenu(){
        yield return new WaitForSeconds(time);
        SceneManager.LoadSceneAsync("Menu");
    }
}

