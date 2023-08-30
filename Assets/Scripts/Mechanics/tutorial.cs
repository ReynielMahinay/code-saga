using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{   
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] lines;
    public float textSpeed;

    private int index;

    public static bool onDialog;

    void Start(){
        dialogueText.text = string.Empty;
        startDialogue();

    }

    void Update() {
        
        if(Input.GetMouseButtonDown(0)){
            if(dialogueText.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    void startDialogue(){

        index = 0;
        StartCoroutine(Typeline()); 

    }

    void NextLine(){
        if(index < lines.Length - 1){
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else{
            gameObject.SetActive(false);
        }
    }

    IEnumerator Typeline(){
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ActivateDialog();
            Debug.Log("activate");

        }
    
    }

     private void OnTriggerExit2D(Collider2D other)

    {
        if(other.CompareTag("Player"))
        {
            DeactivateDialog();
            
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
