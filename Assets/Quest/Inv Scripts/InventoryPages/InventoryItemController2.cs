using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController2 : MonoBehaviour
{
Item2 item2;

public void RemoveItem2()
    {
        InventoryManager2.Instance.Remove2(item2);
        Destroy(gameObject);
    }

    public void AddItem(Item2 newItem2){

        item2 = newItem2;
    }

    public void ViewItem()
    {
      switch(item2.itemType2)
      {
        case Item2.ItemType2.Page1:
        OpenPage.Instance.openPage1();
        break;
        case Item2.ItemType2.Page2_1_1:
        OpenPage.Instance.openPage2_1_1();
        break;
        case Item2.ItemType2.Page2_1_2:
        OpenPage.Instance.openPage2_1_2();
        break;
        case Item2.ItemType2.Page2_1_3:
        OpenPage.Instance.openPage2_1_3();
        break;
        case Item2.ItemType2.Page2_1_4:
        OpenPageR1P2.Instance.openPage2_1_4();
        break;
        case Item2.ItemType2.Page2_1_5:
        OpenPageR1P2.Instance.openPage2_1_5();
        break;
        case Item2.ItemType2.Page2:
        OpenPageR2P1.Instance.openPage2();
        break;
        case Item2.ItemType2.Page2_1_7:
        OpenPageR2P1.Instance.openPage2_1_7();
        break;
        case Item2.ItemType2.Page2_1_8:
        OpenPageR2P1.Instance.openPage2_1_8();
        break;
        case Item2.ItemType2.Page2_1_9:
        OpenPageR2P1.Instance.openPage2_1_9();
        break;
        case Item2.ItemType2.Page3:
        OpenPageR3P1.Instance.openPage3();
        break;
        case Item2.ItemType2.Page3_1:
        OpenPageR3P1.Instance.openPage3_1();
        break;
        case Item2.ItemType2.Page3_2:
        OpenPageR3P1.Instance.openPage3_2();
        break;
      }
        
      }
    }

