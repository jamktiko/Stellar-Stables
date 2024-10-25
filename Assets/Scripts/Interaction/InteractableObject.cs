using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Assign a Condition & Result script and this script will use them.")]
    [Space(5)]
    public bool hasBeenCompleted = false;
    [SerializeField] private bool isRepeatable = false;
    [SerializeField] private bool isButtonDeleted = false;
    public ICondition condition;
    public IResult result;

    //public List<ICondition> conditions = new List<ICondition>();
    //public List<IResult> results = new List<IResult>();
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
        if (isButtonDeleted)
        {
            Destroy(this.gameObject);
        }
    }
    //private void Start()
    //{
    //    conditions.AddRange(GetComponents<ICondition>());
    //    results.AddRange(GetComponents<IResult>());
    //}

    //public void OnClick()
    //{
    //    bool allConditionsMet = conditions.Count == 0 || conditions.TrueForAll(condition => condition.IsConditionMet());

    //    if (allConditionsMet && !hasBeenCompleted)
    //    {
    //        ConditionCompleted();
    //    }
    //}

    //private void ConditionCompleted()
    //{
    //    // Execute all results
    //    foreach (var result in results)
    //    {
    //        result.Execute();
    //    }

    //    if (!isRepeatable)
    //    {
    //        hasBeenCompleted = true;
    //    }

    //    if (isButtonDeleted)
    //    {
    //        Destroy(this.gameObject);
    //    }
//}
}
