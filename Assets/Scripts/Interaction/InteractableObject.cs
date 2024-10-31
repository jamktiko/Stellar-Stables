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
            if (!pair.hasBeenCompleted || pair.isRepeatable)
            {
                pair.TryExecute();
            }

            if (pair.AreAllConditionsMet() && pair.deleteButtonOnCompletion)
            {
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }
}
