using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneResult : SceneLoader, IResult
{
    public void Execute()
    {
        LoadScene();
    }
}
