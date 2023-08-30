using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController2 : MonoBehaviour
{
   public static QuestController2 instance;
  [SerializeField]
  public Text enemyQuestCountertxt;
  public int enemyQuestCounter;
  public GameObject panel;
 void Awake()
{
    
    if(instance == null)
    instance =this;

}
void Update()
{
    if(!panel.activeInHierarchy)
    {
        enemyQuestCountertxt.text = "0/3";
        enemyQuestCounter = 0;
    }
    else{}
    if(enemyQuestCounter >= 3)
    {
        panel.SetActive(false);
    }
}
public void QuestCounter()
{
    
    enemyQuestCounter++;
    enemyQuestCountertxt.text = enemyQuestCounter + "/3";

}
}
