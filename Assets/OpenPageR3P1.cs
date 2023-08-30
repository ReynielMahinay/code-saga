using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenPageR3P1 : MonoBehaviour
{
    public static OpenPageR3P1 Instance;
   
   public GameObject panel3;
   public GameObject panel3_1;
    public GameObject panel3_2;
   
   
   public Text Title3;
   public Text Title3_1;
   public Text Title3_2;
   
 
   public Text Description3 ;
   public Text Description3_1 ;
   public Text Description3_2  ;
   private void Awake(){

    Instance  = this;
    
    panel3.SetActive(false);
    panel3_1.SetActive(false);
    panel3_2.SetActive(false);
    
}
   public void openPage3()
    {

        panel3.SetActive(true);
    }
    public void openPage3_1()
    {

        panel3_1.SetActive(true);
    }
    public void openPage3_2()
    {

        panel3_2.SetActive(true);
    }
}
