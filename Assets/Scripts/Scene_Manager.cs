using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] public int Game_Scene_index = 1;


    public void PlayGame()
    {
        SceneManager.LoadScene(Game_Scene_index);
    }
}
