using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
      int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] swords;
    public GameObject weaponHolder;
    public GameObject currentSwords;
    public GameObject activeWeapon1;
    public GameObject activeWeapon2;
    public GameObject activeWeapon3;
     [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        swords = new GameObject[totalWeapons];

        for(int i = 0; i< totalWeapons; i++){
            swords[i] = weaponHolder.transform.GetChild(i).gameObject;
            swords[i].SetActive(false);
        }
        swords[0].SetActive(true);
        currentSwords = swords[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        //next weapon
        if(Input.GetKeyDown(KeyCode.E)){
            
            if(currentWeaponIndex < totalWeapons -1){
                swords[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                swords[currentWeaponIndex].SetActive(true);
            }
        }

            //prev weapon
        if(Input.GetKeyDown(KeyCode.Q)){
            
            if(currentWeaponIndex > 0){
                swords[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                swords[currentWeaponIndex].SetActive(true);
            }
        }

        if(currentWeaponIndex == 0){
            activeWeapon1.SetActive(true);
            activeWeapon2.SetActive(false);
            activeWeapon3.SetActive(false);
        }

        
        if(currentWeaponIndex == 1){
            activeWeapon1.SetActive(false);
            activeWeapon2.SetActive(true);
            activeWeapon3.SetActive(false);
        }

        
        if(currentWeaponIndex == 2){
            activeWeapon1.SetActive(false);
            activeWeapon2.SetActive(false);
            activeWeapon3.SetActive(true);
        }
    
    }
}
