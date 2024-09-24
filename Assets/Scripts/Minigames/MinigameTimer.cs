using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField] private float gameDuration;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject coverObject;
    private float remainingTime;
    private bool isGameActive = true;



    public event Action OnMinigameEnd;


    private void Start()
    {
        remainingTime = gameDuration;

        UpdateTimerText();
    }

    private void Update()
    {
        if (isGameActive)
        {
            remainingTime -= Time.deltaTime;

            UpdateTimerText();

            if (remainingTime <= 0)
            {
                EndMinigame();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("Time remaining: {0:00}:{1:00}", minutes, seconds);
    }

    private void EndMinigame()
    {
        isGameActive = false;
        remainingTime = 0;
        UpdateTimerText();

        OnMinigameEnd?.Invoke();

        coverObject.SetActive(true);
        Time.timeScale = 0;

        Debug.Log("Time's up! The minigame has ended.");
    }

}
