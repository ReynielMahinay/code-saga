using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barricadeActivate : MonoBehaviour
{
    public GameObject controls;
    public GameObject barricad;


    private void Update() {
        removeBar();
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {   
            controls.SetActive(true);
            barricad.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {        
            controls.SetActive(false);
            barricad.SetActive(false);
            
            Destroy(gameObject);
        }
    }

    public void spaceClose(){
        if (Input.GetMouseButtonDown(0)){
            controls.SetActive(false);
            barricad.SetActive(false);
            Debug.Log("click");
            Destroy(gameObject);
        }
    }

    public void removeBar(){
        if(controls.activeInHierarchy == false){
            barricad.SetActive(false);
        }
    }
}
