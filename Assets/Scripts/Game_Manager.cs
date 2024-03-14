using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance;

    public Vector2 PlayerPos;
    public GameObject player;

    public Vector3 endpoint;

    [SerializeField] Image Life1, Life2, Life3, Life4;

    public int Lives;
    private int points; 

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;

        //initialize life counter
        updateLifeCounter(Lives);

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
        updateLifeCounter(Lives);

        if (Lives == 0)
        {
            SceneManager.LoadScene(2); //go to losre screen
        }
    }

    

    private void updateLifeCounter(int l)
    {
        switch (l)
        {
            case 1:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;
            case 2:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;
            case 3:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;
            case 4:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                Life4.gameObject.SetActive(false);
                break;
            case 5:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                Life4.gameObject.SetActive(true);
                break;
            default:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;

        }
    }
    
}
