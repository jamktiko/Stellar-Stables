using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Assign a Condition & Result script and this script will use them.")]
    [Space(5)]
    public bool hasBeenCompleted = false;
    [SerializeField] private bool isRepeatable = false;
    public ICondition condition;
    public IResult result;
    private void Start()
    {
        condition = GetComponent<ICondition>();
        result = GetComponent<IResult>();
    }
    public void OnClick()
    {
        if (condition != null && condition.IsConditionMet() && !hasBeenCompleted)
        {
            ConditionCompleted();
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
