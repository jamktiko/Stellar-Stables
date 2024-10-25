using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ConditionResultPair
{
    [Header("Assign 1 or more conditions and relevant results for each pair")]
    public List<Component> conditions = new List<Component>();
    public List<Component> results = new List<Component>();

    public bool isRepeatable = false;
    public bool deleteButtonOnCompletion = false;
    [Header("For verifying if it completed or manual reset.")]
    public bool hasBeenCompleted = false;

    public bool AreAllConditionsMet()
    {
        //return conditions.Count == 0 || conditions.TrueForAll(condition => condition.IsConditionMet());
        return conditions.Count == 0 || conditions.All(o => ((o as ICondition)?.IsConditionMet() ?? true) == true);
    }

    public void TryExecute()
    {
        if (AreAllConditionsMet() && (!hasBeenCompleted || isRepeatable))
        {
            //foreach (var result in results)
            //{
            //    result.Execute();
            //}

            results.ForEach(c => (c as IResult)?.Execute());

            if (!isRepeatable)
            {
                hasBeenCompleted = true;
            }
        }
    }
}

