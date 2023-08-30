using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPageR2P1 : MonoBehaviour
{
   public static OpenPageR2P1 Instance;
   
   public GameObject panel2_1_7;
   public GameObject panel2_1_8;
    public GameObject panel2_1_9;
    public GameObject panel2;
   
   
   public Text Title2_1_7;
   public Text Title2_1_8;
   public Text Title2_1_9;
   public Text Title2;
   
 
   public Text Description2_1_7  ;
   public Text Description2_1_8  ;
   public Text Description2_1_9  ;
   public Text Description2  ;
   private void Awake(){

    Instance  = this;
    
    panel2_1_7.SetActive(false);
    panel2_1_8.SetActive(false);
    panel2_1_9.SetActive(false);
    panel2.SetActive(false);
    
}
   public void openPage2_1_7()
    {

        panel2_1_7.SetActive(true);
    }
    public void openPage2_1_8()
    {

        panel2_1_8.SetActive(true);
    }
    public void openPage2_1_9()
    {

        panel2_1_9.SetActive(true);
    }
     public void openPage2()
    {

        panel2.SetActive(true);
    }
}
