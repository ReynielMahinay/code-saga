using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InteractableInv : MonoBehaviour
{
    public Button InvWeap;
   public void ActiveButton(){


     InvWeap.interactable = false;

   }
}
