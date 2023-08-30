using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateKeeper : MonoBehaviour
{
    public GameObject slimetut;
    public GameObject slimetut1;
    public GameObject slimetut2;
    public GameObject gateKeeper;
    void Update()
    {
        if(slimetut.activeInHierarchy&&slimetut1.activeInHierarchy&&slimetut2.activeInHierarchy)
        {

        }else
        {
            gateKeeper.SetActive(true);
        }
        
    }
}
