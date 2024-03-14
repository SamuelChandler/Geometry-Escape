using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score =0;
    void Awake()
    {
        score = PlayerPrefs.GetInt("p");

        var Textbox = GetComponent<TextMeshProUGUI>();
        Textbox.text = "Score: " + score.ToString();
    }
}
