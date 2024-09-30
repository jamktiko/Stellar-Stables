using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameScore : MonoBehaviour
{
    public static MinigameScore Instance { get; private set; }

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

    private void OnEnable()
    {
        MinigameTimer.Instance.OnMinigameReset += ResetScore;
    }

    private void OnDisable()
    {
        MinigameTimer.Instance.OnMinigameReset -= ResetScore;
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

    private void ResetScore()
    {

        score = 0;
        UpdateScoreText();

    }

}
