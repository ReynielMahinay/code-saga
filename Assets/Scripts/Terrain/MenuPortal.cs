using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPortal : MonoBehaviour
{   
    public Animator portal;
    Vector3 lastMouseCoordinate = Vector3.zero;

    private void Start() {
        portal.SetTrigger("autoPlay");
        Time.timeScale = 1f;
    }
    void Update()
    {
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
    
        // Then we check if it has moved to the left.
        if(mouseDelta.x < 0 || mouseDelta.x > 0 || mouseDelta.y < 0 || mouseDelta.y > 0){ // Assuming a negative value is to the left.
            portal.SetTrigger("autoPlay");
        }
        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }
}
