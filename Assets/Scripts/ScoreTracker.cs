using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text scoreText; // Drag your UI Text object into this field in the Inspector
    private float score = 0;

    void Start()
    {
        // Initialize score and update UI
        UpdateScoreText();
    }

    void Update()
    {
        // Increase the score every second
        score += Time.deltaTime;

        // Update UI every frame
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Check if the scoreText reference is not null before updating
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        }
    }
}