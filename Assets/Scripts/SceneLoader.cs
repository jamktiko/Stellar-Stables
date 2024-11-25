using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneName sceneToLoad;
    private List<GameObject> ddols = new List<GameObject>();
    public void LoadScene()
    {
        if (sceneToLoad == SceneName.MainMenu)
        {
            CollectDDOLs();
            RemoveDDOLs();
            //Destroy(GameManager.instance.gameObject);
        }

        if (!string.IsNullOrEmpty(sceneToLoad.ToString()) && sceneToLoad != SceneName.None)
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }
        else
        {
            Debug.LogWarning("No scene assigned to load or incorrect enum/scene name.");
        }
    }
    private void CollectDDOLs()
    {
        var dontDestroyObjects = FindObjectsOfType<DontDestroyOnLoad>();

        foreach (var obj in dontDestroyObjects)
        {
            ddols.Add(obj.gameObject);
        }
    }
    public void RemoveDDOLs()
    {
        Debug.Log("deleting DDOLs");

        foreach (var obj in ddols)
        {
            if (obj.gameObject != this.gameObject)
            {
                Destroy(obj.gameObject);
            }
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
