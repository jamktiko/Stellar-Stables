using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MinigameLives : MonoBehaviour
{
    public static MinigameLives Instance { get; private set; }

    [SerializeField] private int availableLives;
    [SerializeField] private TextMeshProUGUI livesText;

    private int remainingLives;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        remainingLives = availableLives;
        UpdateScoreText();
    }

    private void OnEnable()
    {
        MinigameTimer.Instance.OnMinigameReset += ResetLives;
    }

    private void OnDisable()
    {
        MinigameTimer.Instance.OnMinigameReset -= ResetLives;
    }

    private void UpdateScoreText()
    {
        livesText.text = "Remaining Lives: " + remainingLives;
    }

    public void UseLife()
    {
        remainingLives--;
        UpdateScoreText();
        if(remainingLives <= 0)
        {
            MinigameTimer.Instance.TimerZero();
        }
    }

    private void ResetLives()
    {
        remainingLives = availableLives;
    } 

}
