using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance;
    public Vector2 PlayerPos;

    void Awake()
    {
        instance = this;
        
    }



    
    
}
