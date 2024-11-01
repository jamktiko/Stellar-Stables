using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Assign Condition(s) & Result(s) as pairs")]
    public List<ConditionResultPair> conditionResultPairs = new List<ConditionResultPair>();

    public void OnClick()
    {
        CheckConditions();
    }
    public void CheckConditions()
    {
        foreach (var pair in conditionResultPairs)
        {
            Debug.Log("CheckConditions ran");
            if (!pair.hasBeenCompleted || pair.isRepeatable)
            {
                if (pair.TryExecute())
                {
                    this.gameObject.SetActive(false);
                }
            }

        }
    }
}
