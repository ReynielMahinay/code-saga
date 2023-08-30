using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiverMB : MonoBehaviour
{
    public QuestMB questmb;

   public WeaponPointer player;
   public WeaponPointer2 player2;
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
    titleText.text = questmb.title;
    descriptionText.text = questmb.description;
   }
   public void AcceptQuest()
   {

   DeactivateDialog();
    questmb.isActive = true;
    player.questmb = questmb;
    player2.questmb = questmb;
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
