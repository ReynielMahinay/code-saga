using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmationPopUpMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    //UnityAction is block of code for when the confirm&cancel button is clicked
    public void ActivateMenu(string displayText, UnityAction confirmAction, UnityAction cancelAction){

        this.gameObject.SetActive(true);

        //set the displat text
        this.displayText.text = displayText;

        //remove any existing listeners to for confirmation
        //this only removes listeners added through code
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        //adding onclikc listener on both
        confirmButton.onClick.AddListener(() => {
            DeactMenu();
            confirmAction();
        });
        cancelButton.onClick.AddListener(() => {
            DeactMenu();
            cancelAction();
        });
    }

    private void DeactMenu()
    {
        this.gameObject.SetActive(false);
    }
}
