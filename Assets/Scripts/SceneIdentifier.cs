using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneIdentifier : MonoBehaviour
{
    [Header("The scene this object is originally from. \nAssigned automatically on Awake().")]
    public SceneName rootScene;

    private void Awake()
    {
        rootScene = GetCurrentSceneAsEnum();
       // if (GetComponent<DontDestroyOnLoad>()
    }

    public SceneName GetCurrentSceneAsEnum()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneName currentSceneEnum;

        if (Enum.TryParse(currentSceneName, out currentSceneEnum))
        {
            Debug.Log("Current scene as enum is: " + currentSceneEnum);
            return currentSceneEnum;
        }
        else
        {
            Debug.LogWarning("Current scene name does not match any SceneName enum.");
            return SceneName.None;
        }
    }
}
