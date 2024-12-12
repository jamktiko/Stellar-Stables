using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                (bool conditionsMet, bool deleteButtonOnCompletion) = pair.TryExecute();

                AnimationHandler.instance.InteractionFeedback(conditionsMet);

                if (conditionsMet)
                {
                    if (!pair.isRepeatable)
                    {
                        DisableButton();
                    }

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
    public void CheckFailed()
    {
        //Debug.Log("Check failed.");
    }
    public void DisableButton()
    {
        Button button = GetComponent<Button>();
        Destroy(button);

        //Debug.Log("Check success!");
    }
}
