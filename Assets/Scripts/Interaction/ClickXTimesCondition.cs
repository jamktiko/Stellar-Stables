using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickXTimesCondition : MonoBehaviour, ICondition
{
    public int requiredClicks;
    public int currentClicks;

    public bool IsConditionMet()
    {
        currentClicks++;
        return currentClicks >= requiredClicks;
    }
    public void ResetCondition()
    {
        currentClicks = 0;
    }
}

//[CreateAssetMenu(menuName = "Interaction/Conditions/ClickXTimesCondition")]
//public class ClickXTimesCondition : ScriptableCondition
//{
//    public int requiredClicks;
//    public int currentClicks;

//    public override bool IsConditionMet()
//    {
//        currentClicks++;
//        return currentClicks >= requiredClicks;
//    }

//    public override void ResetCondition()
//    {
//        currentClicks = 0;
//    }
//}
