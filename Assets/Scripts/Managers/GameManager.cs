using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<GameObject> interactables = new List<GameObject>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }

        interactables = new List<GameObject>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Start()
    {
        //CollectDDOLs();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            FindCanvases();
            ApplyDDOL();
            ToggleCanvases();
            UnpauseGame();
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    private void ApplyDDOL()
    {
        foreach (GameObject canvas in interactables)
        {
            if (canvas != null && canvas.GetComponent<DontDestroyOnLoad>() == null)
            {
                canvas.AddComponent<DontDestroyOnLoad>();
                //Debug.Log($"Added DDOL to interactables: {canvas}");
            }
        }
    }

    private void FindCanvases()
    {
        GameObject[] allCanvas = GameObject.FindGameObjectsWithTag("Canvas");

        foreach (GameObject canvasFound in allCanvas)
        {
           //Debug.Log($"canvasFound is: {canvasFound}");

            if (!ContainsObjectWithName(canvasFound.name))
            {
                interactables.Add(canvasFound);
                //ddols.Add(canvasFound);
                //Debug.Log($"canvasFound ADDED: {canvasFound}");
            }
            else
            {
                canvasFound.SetActive(false);
            }
        }
    }
    private bool ContainsObjectWithName(string name)
    {
        foreach (GameObject go in interactables)
        {
            if (go.name == name)
            {
                return true;
            }
        }
        return false;
    }
    private void ToggleCanvases()
    {
        foreach (GameObject canvas in interactables)
        {
            canvas.SetActive(false);

            SceneName rootSceneOfCanvas = canvas.GetComponent<SceneIdentifier>().rootScene;

            if (IsActiveScene(rootSceneOfCanvas))
            {
                canvas.SetActive(true);
                //canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            }
        }
    }
    public bool IsActiveScene(SceneName sceneEnum)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        return activeSceneName == sceneEnum.ToString();
    }
}