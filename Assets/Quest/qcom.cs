using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qcom : MonoBehaviour
{
    public void Setup(int score){
   gameObject.SetActive(true);
    }
    public void Close(){
        gameObject.SetActive(false);
    }
}
