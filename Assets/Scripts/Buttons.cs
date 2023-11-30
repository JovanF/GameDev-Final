using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Buttons : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("Score");

        // Display saved score
        scoreText.text = "Final Score: " + savedScore;
    }

    public void Begin()
    {
        SceneManager.LoadScene("TreeScene");
    }

    public void End()
    {
        Application.Quit();
    }

}