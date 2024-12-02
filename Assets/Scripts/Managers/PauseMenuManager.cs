using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager Instance { get; private set; }

    private InputAction pauseAction;
    private bool isPaused = false;

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
        pauseAction = new UIControls().UI.Pause;
        pauseAction.Enable();
        pauseAction.performed += TogglePauseMenu;

    }

    private void OnDisable()
    {
        pauseAction.Disable();
        pauseAction.performed -= TogglePauseMenu;
    }

    public void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                Debug.Log(Time.timeScale);
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync("PauseMenu");
            } 
        }
    }

    public void TogglePauseMenu()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                Debug.Log(Time.timeScale);

                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync("PauseMenu");
            } 
        }
    }
}
