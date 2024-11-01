using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompletedCondition : MonoBehaviour, ICondition
{
    [Header("The interactable that needs to be completed before this one can be completed")]
    [SerializeField] private InteractableObject interactableObject;
    public bool IsConditionMet()
    {
        bool allConditionsDone = false;

        allConditionsDone = interactableObject.conditionResultPairs.TrueForAll(condition => condition.hasBeenCompleted);
        
        return allConditionsDone;
    }
}
