using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPageR1P2 : MonoBehaviour
{
   public static OpenPageR1P2 Instance;
   
   public GameObject panel2_1_4;
   public GameObject panel2_1_5;
    //public GameObject panel2_1_6;
   
   
   public Text Title2_1_4;
   public Text Title2_1_5;
  // public Text Title2_1_6;
   
 
   public Text Description2_1_4  ;
   public Text Description2_1_5  ;
   //public Text Description2_1_6  ;
   private void Awake(){

    Instance  = this;
    
    panel2_1_4.SetActive(false);
    panel2_1_5.SetActive(false);
   // panel2_1_6.SetActive(false);
    
}
   public void openPage2_1_4()
    {

        panel2_1_4.SetActive(true);
    }
    public void openPage2_1_5()
    {

        panel2_1_5.SetActive(true);
    }
    //public void openPage2_1_6()
    //{
//
 // / //     panel2_1_6.SetActive(true);
  //}
}
