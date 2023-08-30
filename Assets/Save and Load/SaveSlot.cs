using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;

    [SerializeField] private TextMeshProUGUI HpCountText;
    [SerializeField] private TextMeshProUGUI CrystalCountText;

    [Header("Clear Data Button")]
    [SerializeField] private Button clearButton;

    //confirmation if there is a data or not
    public bool hasData { get; private set; } = false;
    private Button saveSlotButton;

    private void Awake() {
        saveSlotButton = this.GetComponent<Button>();
    }


    public void SetData(GameData data){

        //to know if there is no data profileId
        if(data == null){
            hasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            clearButton.gameObject.SetActive(false);
        }
        //there is a data profileId
        else {

            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            clearButton.gameObject.SetActive(true);

            HpCountText.text = "HP: " + data.healthCount;
            CrystalCountText.text = "Crystal: " + data.CurrentCount;

        }
    }

    public string GetProfileId(){

        return this.profileId;
    }

    public void SetInteractable(bool interactable){
        saveSlotButton.interactable = interactable;
        clearButton.interactable = interactable;
    }
}
