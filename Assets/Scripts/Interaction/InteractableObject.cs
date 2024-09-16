using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //[("Assign a Condition & Result script and this script will use them.")]
    public ICondition condition;
    public IResult result;

    private void Start()
    {
        condition = GetComponent<ICondition>();
        result = GetComponent<IResult>();
    }
    public void OnClick()
    {
        if (condition != null && condition.IsConditionMet())
        {
            result.Execute();
        }
        else if (condition == null) //for no conditions -> click once
        {
            result.Execute();
        }
    }
}
