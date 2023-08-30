using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item2", menuName ="Item2/Create New Item2")]
public class Item2 : ScriptableObject
{
   public int id2;
   public string itemName2;
   
   public Sprite icon2;
   public ItemType2 itemType2;

public enum ItemType2
{
   Page1,
   Page2,
   Page2_1_1,
   Page2_1_2,
   Page2_1_3,
   Page2_1_4,
   Page2_1_5,
   Page2_1_6,
   Page2_1_7,
   Page2_1_8,
   Page2_1_9,
   Page3,
   Page3_1,
   Page3_2,

}

   
}
