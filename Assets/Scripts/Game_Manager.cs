using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game_Manager : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{

    public bool mouseButton1;//tells when button 1 is being pressed down

    public static Game_Manager instance;

    void Awake()
    {
        instance = this;
        mouseButton1 = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseButton1 = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseButton1 = false;
    }
    
    
}
