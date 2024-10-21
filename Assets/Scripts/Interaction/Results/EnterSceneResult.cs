using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class EnterSceneResult : SceneLoader, IResult
{
    public void Execute()
    {
        LoadScene();
    }
}
