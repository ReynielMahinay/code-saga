using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem){

        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
        case Item.ItemType.Potion1:
        damagePlayer.Instance.Heal1();
        break;
        case Item.ItemType.Potion2:
        damagePlayer.Instance.Heal2();
        break;
        case Item.ItemType.Potion3:
        damagePlayer.Instance.Heal3();
        break;
        }
        RemoveItem();
    }
}
