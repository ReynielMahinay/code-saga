using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle1Quest1 : MonoBehaviour
{
    public Quest quest;

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

   public void OpenQuestWindow()
   {
    ActivateDialog();
    titleText.text = quest.title;
    descriptionText.text = quest.description;
   }
   public void AcceptQuest()
   {

    DeactivateDialog();
    quest.isActive = true;
    player.quest = quest;
    player2.quest = quest;
    player3.quest = quest;
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
