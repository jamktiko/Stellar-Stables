using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishScore : MonoBehaviour
{
    public static FishScore Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

}
