using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TittleTrigger : MonoBehaviour
{   
    public GameObject titlePanel;
    public Animator titleName;
    private float delay = 1.2f;
   
   // public Animator titleanim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(title());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            titlePanel.SetActive(false);
        }
    }


    IEnumerator title()
    {
        yield return new WaitForSeconds(delay);
        titlePanel.SetActive(true);
        titleName.SetTrigger("playAnim");
    }

}
