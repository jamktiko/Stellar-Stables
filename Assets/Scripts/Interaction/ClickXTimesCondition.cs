using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickXTimesCondition : MonoBehaviour, ICondition
{
    public int requiredClicks;
    public int currentClicks;

    //public ClickXTimesCondition(int clickRequired)
    //{
    //    requiredClicks = clickRequired;
    //    currentClicks = 0;
    //}

    public bool IsConditionMet()
    {
        currentClicks++;
        return currentClicks >= requiredClicks;
    }
}
