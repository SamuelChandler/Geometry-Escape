using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Setting_Menu : MonoBehaviour
{
    private bool InGame;
    [SerializeField] private Canvas _canvas;

    public static Pause_Setting_Menu instance;

    private void Awake()
    {
        instance = this;
        InGame = false;
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Manager.instance != null) { InGame = true; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _canvas.enabled = true;

            //make player invisible
            Game_Manager.instance.playerGO.SetActive(false);
            if (Game_Manager.instance.player._traveling) { Game_Manager.instance.player.currentRail_Riding.SetActive(false); }
            if (Game_Manager.instance.player._railBeingCreated) { Game_Manager.instance.player.currentRail_Created.SetActive(false); }

            Time.timeScale = 0f;
            

        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        _canvas.enabled = false;
        Game_Manager.instance.playerGO.SetActive(true);
        if (Game_Manager.instance.player._traveling) { Game_Manager.instance.player.currentRail_Riding.SetActive(true); }
        if (Game_Manager.instance.player._railBeingCreated) { Game_Manager.instance.player.currentRail_Created.SetActive(true); }

        
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
