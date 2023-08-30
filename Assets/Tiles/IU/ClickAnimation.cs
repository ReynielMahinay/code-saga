using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Image img;
    [SerializeField] private Sprite defualt, pressed;
    
    public void OnPointerDown(PointerEventData eventData){
        img.sprite = pressed;
    }

    public void OnPointerUp(PointerEventData eventData){
        img.sprite = defualt;
    }

}
