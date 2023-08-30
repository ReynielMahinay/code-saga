using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNpc : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject dialoguePanel;
   public Text dialogueText;
   public string[] dialogue;
   private int index;

   public GameObject contButton;
   public float wordSpeed;
   public bool playerIsClose;
   public static bool onDialog;

void Start(){
        onDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose && !dialoguePanel.activeInHierarchy)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                ActivateDialog();
                StartCoroutine(Typing());
                contButton.SetActive(false);
            }
        }

        if(dialogueText.text == dialogue[index])
    {
        contButton.SetActive(true);
    }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        DeactivateDialog();
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        contButton.SetActive(false);
        if(index < dialogue.Length - 1 )
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
        zeroText();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            zeroText();
        }
    
    

    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            
        }

    }
     void ActivateDialog(){
        dialoguePanel.SetActive(true);
        onDialog = true;
    }

    void DeactivateDialog(){
        dialoguePanel.SetActive(false);
        onDialog = false;
    }
}

