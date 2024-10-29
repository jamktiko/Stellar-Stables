using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //private List<TrackableObject> trackedObjects = new List<TrackableObject>();


    //when scene is changed, find and save info on all objects in the previous scene before changing
    //store guid, position, active/inactive state, puzzle completed state (if any)
    //when new scene is loaded, check if there's info stored on that scene
    //if not, find all objects via guid and load their info

    //game manager finds all objects
    //how?
    //1) each one has a script and they tell the game manager to register them?
    //no, cus objs reset, they will register again


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
    }

    //public void RegisterObject(TrackableObject obj)
    //{
    //    if (!trackedObjects.Contains(obj))
    //        trackedObjects.Add(obj);
    //}
}

//[System.Serializable]
//public class ObjectData
//{
//    public string objectName;
//    public Vector2 position;
//    public bool isDeleted;
//    public bool isObjectCompleted;
//}