using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneName sceneToLoad;

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad.ToString()) && sceneToLoad != SceneName.None)
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }
        else
        {
            Debug.LogWarning("No scene assigned to load or incorrect enum/scene name.");
        }
    }
}
public enum SceneName
{
    None,
    MainMenu,
    Area1_Ocean,
    Area2_Desert,
    Area3_Forest,
    Home,
    Stables,
    Minigame_Fishing,
    Minigame_Music,
    Minigame_Workout
}
