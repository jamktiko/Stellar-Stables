using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameTimer : MonoBehaviour
{

    public static MinigameTimer Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    [SerializeField] private float gameDuration;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject coverObject;
    private float remainingTime;
    private bool isGameActive = true;

    public event Action OnMinigameEnd;
    public event Action OnMinigameReset;


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

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fishing Testing");
        //remainingTime = gameDuration;
        //UpdateTimerText();

        //coverObject.SetActive(false);
        //Time.timeScale = 1;

        //isGameActive = true;
        OnMinigameReset?.Invoke();

        //Debug.Log("Mingame reset.");
    }

}
