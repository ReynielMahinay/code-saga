using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrystalCounter : MonoBehaviour, IDataPersistent
{
    public static CrystalCounter instance;
    public int CurrentCount = 0;

    public Button smallButton;
    public Button mediumButton;
    public Button largeButton;
    public Text number;

    public bool canBuy;

    private int smallPrice = 3;
    private int mediumPrice = 5;
    private int largePrice = 7;

    private int crsytal;
    
    // Start is called
    void Start()
    {
        number.text = " " + CurrentCount.ToString();
        
    }

    void Update()
    {
        AddCrystal(crsytal);
        smallCanBuy();   
        mediumCanBuy();
        largeCanBuy();
        
    }

    public void smallCanBuy(){
          if(CurrentCount>=smallPrice ){
            canBuy = true;
        }
            else{
                canBuy = false;
            }
            if(canBuy == true){
                smallButton.interactable = true;
            }
            else{
                smallButton.interactable = false;
            }    
    }

    public void mediumCanBuy(){
         if(CurrentCount>=mediumPrice ){
            canBuy = true;
        }
            else{
                canBuy = false;
            }
            if(canBuy == true){
                mediumButton.interactable = true;
            }
            else{
                mediumButton.interactable = false;
            }    
    }

    public void largeCanBuy(){
         if(CurrentCount>=largePrice ){
            canBuy = true;
        }
            else{
                canBuy = false;
            }
            if(canBuy == true){
                largeButton.interactable = true;
            }
            else{
                largeButton.interactable = false;
            }    
    }
 public void CompQuest(){
        CurrentCount += 10;
        number.text = " " + CurrentCount.ToString();
        
    }
    public void AddCrystal(int crsytal){
        CurrentCount += crsytal;
        number.text = " " + CurrentCount.ToString();
        instance = this;
    }
        
    public void smallPots(){
        CurrentCount -= smallPrice;
        number.text = " " + CurrentCount.ToString(); 
    }

    public void mediumPots(){
        CurrentCount -= mediumPrice;
        number.text = " " + CurrentCount.ToString(); 
    }

    public void largePots(){
        CurrentCount -= largePrice;
        number.text = " " + CurrentCount.ToString(); 
    }
    
            
    public void LoadData(GameData data){
        this.CurrentCount = data.CurrentCount;
    }

    public void SaveData(GameData data)
    {
        data.CurrentCount = this.CurrentCount;
    }

}
