using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResult : MonoBehaviour, IResult
{
    public string message = "Result Executed";

    public void Execute()
    {
        Debug.Log(message);
    }
}
