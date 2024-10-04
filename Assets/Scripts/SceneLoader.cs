using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Scene sceneToLoad;
    public enum Scene
    {
        None,
        MainMenu,
        Area1_Ocean,
        Area2_Desert,
        Area3_Forest,
        Home,
        Stables
    }
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad.ToString()) && sceneToLoad != Scene.None)
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }
        else
        {
            Debug.LogWarning("No scene assigned to load or incorrect enum/scene name.");
        }
    }
}
