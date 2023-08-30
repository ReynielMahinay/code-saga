using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
   public Quest quest;

   public WeaponPointer player;
   public GameObject questWindow;
   public Text titleText;
   public Text descriptionText;
   public static bool onDialog;
void Start(){
        onDialog = false;
    }
   public void OpenQuestWindow()
   {
    onDialog = false;
    
    titleText.text = quest.title;
    descriptionText.text = quest.description;
    ActivateDialog();
   }
   public void AcceptQuest()
   {

    DeactivateDialog();
    quest.isActive = true;
    player.quest = quest;
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
