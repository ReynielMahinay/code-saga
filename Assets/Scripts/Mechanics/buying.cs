using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buying : MonoBehaviour
{
     public static CrystalCounter instance;
     public GameObject button;
     public int price = 5;
     public Text number;
     public GameObject storepanel;
     public int CurrentCount = 0;
     
    private void Update()
    {
        
        //number.text = " " + CurrentCount.ToString();
        CurrentCount = int.Parse(number.text);
        
      
            if(int.Parse(number.text)>=price){
                button.SetActive(true);
                
            }//-= price;
            //number.text = " " + CurrentCount.ToString();
            
            else if(int.Parse(number.text)<price){
                button.SetActive(false);
            }
            else{}
    }
    
}
