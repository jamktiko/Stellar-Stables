using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInventoryManager : MonoBehaviour
{
    [Header("Scenes where the Player inventory is active.")]
    [SerializeField] private SceneName[] enabledOnScenes;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StaticInterface.instance.ClearInventory();
        DynamicInterface.instance.ClearInventory();
        TogglePlayerInventory();
        ToggleStablesInventory();
    }

    private void TogglePlayerInventory()
    {
        bool shouldEnable = false;

        foreach (SceneName scene in enabledOnScenes)
        {
            if (IsActiveScene(scene))
            {
                shouldEnable = true;
                //Debug.Log($"ENABLED. Scene is {scene} and active scene is {SceneManager.GetActiveScene().name}");
                break;
            }
        }

        //Debug.Log($"StaticInterface is: {StaticInterface.instance.gameObject.name}");
        StaticInterface.instance.gameObject.SetActive(shouldEnable);
    }
    private void ToggleStablesInventory()
    {
        bool shouldEnable = false;

            if (IsActiveScene(SceneName.Stables))
            {
                shouldEnable = true;
                //Debug.Log($"ENABLED on STABLES. active scene is {SceneManager.GetActiveScene().name}");
            }
        
        DynamicInterface.instance.gameObject.SetActive(shouldEnable);
    }
    public bool IsActiveScene(SceneName sceneEnum)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        return activeSceneName == sceneEnum.ToString();
    }
}
