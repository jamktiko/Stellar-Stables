using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class EnterSceneResult : SceneLoader, IResult
{
    public void Execute()
    {
        Invoke(nameof(EnterWithDelay), 1.5f);
    }
    public void EnterWithDelay()
    {
        LoadScene();
    }
}
