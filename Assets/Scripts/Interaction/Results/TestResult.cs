using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestResult : MonoBehaviour, IResult
{
    public string message = "Result Executed";
    public TextMeshProUGUI textbox;
    public GameObject obj;

    public void Execute()
    {
        Debug.Log(message);
        textbox.text = message;
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}

//[CreateAssetMenu(menuName = "Interaction/Results/TestResult")]
//public class TestResult : ScriptableResult
//{
//    public string message = "Result Executed";

//    public override void Execute()
//    {
//        Debug.Log(message);
//    }
//}
