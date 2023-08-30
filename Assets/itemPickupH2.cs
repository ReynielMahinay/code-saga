using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickupH2 : MonoBehaviour
{
    public Item Item;
   public damagePlayer heal;
   public GameObject player;

   void Pickup(){
    //InventoryManager.Instance.Add(Item);
    Destroy(gameObject);

   }
   private void OnTriggerEnter2D (Collider2D other){
   if(other.gameObject.CompareTag("Player"))
   {
   Pickup();
    heal.Heal2();
   }
   }
}
