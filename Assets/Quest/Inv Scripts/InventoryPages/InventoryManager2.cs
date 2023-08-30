using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager2 : MonoBehaviour
{
    public static InventoryManager2 Instance;
    public List<Item2> Items2 = new List<Item2>();

    public Transform ItemContent2;
    public GameObject InventoryItem2;
    public InventoryItemController2[] InventoryItems2;

    private void Awake(){
        Instance = this;
    }
    public void Add(Item2 item2)
    {
        Items2.Add(item2);
    }
    public void Remove2(Item2 item2)
{
    Items2.Remove(item2);
}
    

    public void ListItems(){
        foreach (Transform item2 in ItemContent2){
            Destroy(item2.gameObject);

        }
        

    foreach (var item2 in Items2)
    {
        GameObject obj = Instantiate(InventoryItem2 , ItemContent2);
        var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
    
        itemName.text = item2.itemName2;
        itemIcon.sprite = item2.icon2;
    
    }
    SetInventoryItems2();
    }
    public void SetInventoryItems2(){

        InventoryItems2 = ItemContent2.GetComponentsInChildren<InventoryItemController2>();

        for (int  i = 0; i < Items2.Count; i++){
            InventoryItems2[i].AddItem(Items2[index: i]);
        }
}
public void Clean2(){
        foreach (Transform items2 in ItemContent2){
            Destroy(items2.gameObject);

        }
}}
