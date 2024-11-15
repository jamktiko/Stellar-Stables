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
        if (StaticInterface.instance.inventory.EmptySlotCount != 0)
        {
            foreach (var pair in conditionResultPairs)
            {
                if (!pair.hasBeenCompleted || pair.isRepeatable)
                {
                    (bool conditionsMet, bool deleteButtonOnCompletion) = pair.TryExecute();

                    InteractCheckHandler.instance.RunAnimation(conditionsMet);

                    if (conditionsMet)
                    {
                        CheckSucceeded();

                        if (deleteButtonOnCompletion)
                        {
                            this.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        CheckFailed();
                    }
                }
            }
        }
        else
        {
            CheckFailed();
            InteractCheckHandler.instance.RunAnimation(false);
        }
    }
    public void CheckFailed()
    {
        Debug.Log("Check failed.");
    }
    public void CheckSucceeded()
    {
        Debug.Log("Check success!");
    }
}
