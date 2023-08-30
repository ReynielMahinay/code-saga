using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalActivate : MonoBehaviour
{   
    public Animator portal;
    public static bool isReady;
    private int time = 15;
    // Start is called before the first frame update
    void Start()
    {
          isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        portalActivated();
    }

    
    public void portalActivated(){

            StartCoroutine(portalReady());

    }

    private IEnumerator portalReady(){
        
        yield return new WaitForSeconds(time);
        portal.SetTrigger("activated");
        isReady = true;

    }
}
