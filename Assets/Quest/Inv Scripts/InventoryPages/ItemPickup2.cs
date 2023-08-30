using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup2 : MonoBehaviour
{  
    public CorrectAnswer sfx; 
   public Item2 Item2;
   
   void Pickup(){
    InventoryManager2.Instance.Add(Item2);
    Destroy(gameObject);
   
   }
   private void OnTriggerEnter2D (Collider2D other){
   if(other.gameObject.CompareTag("Player"))
   {
   Pickup();
   sfx.correctSound.Play();

   }
   }
   }

