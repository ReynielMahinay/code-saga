using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPage : MonoBehaviour
{
    public static OpenPage Instance;
   public GameObject panel1;
   public GameObject panel2_1_1;
   public GameObject panel2_1_2;
    public GameObject panel2_1_3;
    
    
   public Text Title1;
   public Text Title2_1_1;
   public Text Title2_1_2;
   public Text Title2_1_3;
   
   
   public Text Description1  ;
   public Text Description2_1_1  ;
   public Text Description2_1_2  ;
   public Text Description2_1_3  ;
   
   private void Awake(){

    Instance  = this;
    panel1.SetActive(false);
    panel2_1_1.SetActive(false);
    panel2_1_2.SetActive(false);
    panel2_1_3.SetActive(false);
   
    
}
   public void openPage1()
    {

        panel1.SetActive(true);
        

    }
    public void openPage2_1_1()
    {

        panel2_1_1.SetActive(true);
    }
    public void openPage2_1_2()
    {

        panel2_1_2.SetActive(true);
    }
     public void openPage2_1_3()
    {

        panel2_1_3.SetActive(true);
    }

    
   
}
