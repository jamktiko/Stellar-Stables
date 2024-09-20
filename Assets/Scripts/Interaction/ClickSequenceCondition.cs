using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSequenceCondition : MonoBehaviour, ICondition
{
    //public static ClickSequenceCondition instance;

    [SerializeField] private List<int> correctSequence = new List<int>{ 0, 1, 2, 3, 4 };
    private int currentIndex = 0;

    //private void Awake()
    //{
    //   instance = this;
    //    if (instance != null)
    //    {
    //        Debug.LogWarning($"Multiple instances of {this.GetType().Name} found! Deleting extra.");
    //        Destroy(this);
    //    }
    //}

    public void CheckStep(int buttonIndex)
    {
        if (currentIndex < correctSequence.Count)
        {
            if (buttonIndex == correctSequence[currentIndex])
            {

                currentIndex++;


                Debug.Log("Correct button clicked.");
            }
            else
            {
                Debug.Log("Wrong button. Reset.");
                currentIndex = 0;
            }
        }
    }
    public bool IsConditionMet()
    {
        return currentIndex >= correctSequence.Count;
    }
}
