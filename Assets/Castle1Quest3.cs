using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle1Quest3 : MonoBehaviour
{
   public QuestLN questln;

   public WeaponPointer player;
   public WeaponPointer2 player2;
   public WeaponPointer3 player3;
   public GameObject questWindow;
   public Text titleText;
   public Text descriptionText;
   public static bool onDialog;
   void Start(){
        onDialog = false;
    }

   public void OpenQuestWindowLN()
   {
    ActivateDialog();
    titleText.text = questln.title;
    descriptionText.text = questln.description;
   }
   public void AcceptQuestLN()
   {

    DeactivateDialog();
    questln.isActive = true;
    player.questln = questln;
    player2.questln = questln;
    player3.questln = questln;
   }
    void ActivateDialog(){
        questWindow.SetActive(true);
        onDialog = true;
    }

    void DeactivateDialog(){
        questWindow.SetActive(false);
        onDialog = false;
    }
}
