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
    public GameObject player;

    public Vector3 endpoint;

    public int Lives;
    private int points; 

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        
    }

    void PointChange(int delta)
    {
        points += delta;
    }

    void EndGame()
    {
        SceneManager.LoadScene(2);// loads the you lose screen 
    }

    public void destroyPlayer()
    {
        //any events for destroying the player
        Destroy(player);
        Lives--;

        if (Lives == 0)
        {
            SceneManager.LoadScene(2); //go to losre screen
        }
    }
    
    
    
}
