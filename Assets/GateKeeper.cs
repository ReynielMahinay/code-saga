using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateKeeper : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject dialoguePanel;
   public Text dialogueText;
   public string[] dialogue;
   private int index;
   
   public GameObject fkey;

   public GameObject contButton;
 
   
   public float wordSpeed;
   public bool playerIsClose;
   public bool playerIsMoving;

    public static bool onDialog;

    void Start(){
        onDialog = false;
    }

    // Update is called once per frame
    void Update()

   
    {
         if(!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.A) ||  !Input.GetKey(KeyCode.S) ||  !Input.GetKey(KeyCode.D)) 
         {
            playerIsMoving = false; 
            Debug.Log("idle");
         }
         if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.D))
         {
            playerIsMoving = true;
            Debug.Log("moving");
         }


        if(Input.GetKeyDown(KeyCode.F) && playerIsClose && !dialoguePanel.activeInHierarchy && !playerIsMoving)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                
                zeroText();
                
            }
            else
            {
                ActivateDialog();
                StartCoroutine(Typing());
                contButton.SetActive(value: false);
                fkey.SetActive(false);
                
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
            
            fkey.SetActive(true);
        zeroText();
        
        }

    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();            
            fkey.SetActive(false); 

        }

    }

    public void ActivateDialog(){
        dialoguePanel.SetActive(true);
        onDialog = true;
    }

    public void DeactivateDialog(){
        dialoguePanel.SetActive(false);
        onDialog = false;
        fkey.SetActive(true);
    }
}
