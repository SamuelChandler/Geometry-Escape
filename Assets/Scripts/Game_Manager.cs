using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance;
    public Vector2 PlayerPos;
    public Vector3 endpoint;
    private int points; 

    void Awake()
    {
        instance = this;
        
    }

    void PointChange(int delta)
    {
        points += delta;
    }

    void EndGame()
    {
        SceneManager.LoadScene(2);// loads the you lose screen 
    }

    
    
}
