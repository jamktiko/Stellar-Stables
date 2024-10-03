using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Assign a Condition & Result script and this script will use them.")]
    [Space(5)]
    [SerializeField] private bool hasBeenCompleted = false;
    [SerializeField] private bool isRepeatable = false;
    public ICondition condition;
    public IResult result;

    //public ScriptableCondition condition;
    //public ScriptableResult result;

    private void Start()
    {
        condition = GetComponent<ICondition>();
        result = GetComponent<IResult>();
    }
    public void OnClick()
    {
        //if (!hasBeenClicked) //reset the SO if this is a new click
        //{
        //    condition.ResetCondition();
        //    hasBeenClicked = true;
        //}

        if (condition != null && condition.IsConditionMet() && !hasBeenCompleted)
        {
            ConditionCompleted();
            //condition.ResetCondition();
        }
        else if (condition == null && !hasBeenCompleted) //for no conditions -> click once
        {
            ConditionCompleted();
        }
    }
    private void ConditionCompleted()
    {
        result.Execute();
        if (!isRepeatable)
        {
            hasBeenCompleted = true;
        }
    }
}
