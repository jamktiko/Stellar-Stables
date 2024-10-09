using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSequenceStep : MonoBehaviour
{
    [SerializeField] private int orderInSequence;
    [SerializeField] private ClickSequenceCondition rootCondition;

    public void CheckSequenceStep()
    {
        rootCondition.CheckStep(orderInSequence);
    }
}
