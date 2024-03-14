using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance;

    public Vector2 PlayerPos;
    public Player player;
    public GameObject playerGO;
    public GameObject playerPF;
    public bool PlayerDied;

    public Vector3 endpoint;

    [SerializeField] Image Life1, Life2, Life3, Life4;
    [SerializeField] GameObject _scoreCounter;

    public int Lives;
    private int points = 0; 

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        PlayerDied = false;
        //initialize life counter
        updateLifeCounter(Lives);

        playerGO = Instantiate(playerPF);
    }

    private void FixedUpdate()
    {
        PointChange(1); //get 1 point every frame 
    }

    public void PointChange(int delta)
    {
        points += delta;
        var textbox = _scoreCounter.GetComponent<TextMeshProUGUI>();
        textbox.text= points.ToString();
    }

    void EndGame()
    {
        SceneManager.LoadScene(2);// loads the you lose screen 
    }

    public void destroyPlayer()
    {
        //any events for destroying the player

        Lives--;
        updateLifeCounter(Lives);

        //destroy all enemies 

        //destroy curent player 
        player.DestroyMyself();
        
        if (Lives == 0)
        {
            PlayerPrefs.SetInt("p", points); //save points for the next scene
            EndGame(); //go to losre screen
        }

        


        //spawn new player
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        playerGO = Instantiate(playerPF);
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
