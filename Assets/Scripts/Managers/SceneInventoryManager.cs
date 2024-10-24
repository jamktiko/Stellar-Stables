using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInventoryManager : MonoBehaviour
{
    [SerializeField] private Scene[] enabledOnScenes;
    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ToggleInventory(); // Only call this when a new scene is loaded
    }

    private void ToggleInventory()
    {
        bool shouldEnable = false;

        foreach (Scene scene in enabledOnScenes)
        {
            if (IsActiveScene(scene))
            {
                shouldEnable = true;
                Debug.Log($"ENABLED. Scene is {scene} and active scene is {SceneManager.GetActiveScene().name}");
            }
            else
            {
                shouldEnable = false;
                Debug.Log($"DISABLED. Scene is {scene} and active scene is {SceneManager.GetActiveScene().name}");
            }
        }

        gameObject.SetActive(shouldEnable);
    }
    public bool IsActiveScene(Scene sceneEnum)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        return activeSceneName == sceneEnum.ToString();
    }
}
