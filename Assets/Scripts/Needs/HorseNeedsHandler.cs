using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseNeedsHandler : MonoBehaviour
{

    [SerializeField] private HorseSO _horse;
    [SerializeField] private int _overallHorseHappiness = 100;
    [SerializeField] private int _positiveNeighbourModifier;
    [SerializeField] private int _negativeNeighbourModifier;
    [SerializeField] private int _horseHungerSatisfcation = 10;
    [SerializeField] private int _horseHunger = 0;

    private bool _isPreferredDecor;

    public void Feed(FoodTypeSO inputFood)
    {

        if(inputFood == null)
        {
            Debug.LogWarning("Input food is null.");
            return;
        }
        else if(inputFood == _horse.GetFoodType())
        {
            Debug.Log("Food type is correct. Decreasing " + _horse.GetHorseName() + "'s hunger.");  
            DecreaseHunger();
        }
        else
        {
            Debug.Log("Food type "+inputFood.GetFoodName() + " is incompatible with "+_horse.GetHorseName()+".");
        }

    }

    private void DecreaseHunger()
    {
        _horseHunger -= _horseHungerSatisfcation;
    }

    public void CheckDecor(DecorTypeSO inputDecor)
    {
        if (inputDecor == null)
        {
            Debug.LogWarning("Input decor is null.");
            return;
        }
        else if (inputDecor == _horse.GetDecorationType())
        {
            Debug.Log("Decor type is correct.");
            _isPreferredDecor = true;
        }
        else
        {
            Debug.Log("Decor type " + inputDecor.GetDecorName() + " is incorrect for " + _horse.GetHorseName() + ".");
            _isPreferredDecor = false;
        }
    }

    public void CheckNeighbours(HorseSO neighbourSlot1, HorseSO neighbourSlot2)
    {

        HorseSO[] preferredNeighbours = _horse.GetPreferredNeighbours();
        HorseSO[] negativeNeighbours = _horse.GetNegativeNeighbours();

        PreferenceEnum[] currentNeighbourPreference = _horse.GetCurrentNeighbourPreference();

        for (int i = 0; i < currentNeighbourPreference.Length; i++) // Removes happiness modifiers before re-check
        {
            if (currentNeighbourPreference[i] == PreferenceEnum.Positive)
            {
                DecreaseHappiness(_positiveNeighbourModifier);
            }
            else if (currentNeighbourPreference[i] == PreferenceEnum.Negative)
            {
                IncreaseHappiness(_negativeNeighbourModifier);
            }
        }

        currentNeighbourPreference = new PreferenceEnum[2] { PreferenceEnum.Neutral, PreferenceEnum.Neutral }; // Resets preferences to neutral for re-check

        for (int i = 0; i < preferredNeighbours.Length; i++)
        {
            if (neighbourSlot1 != null && neighbourSlot1 == preferredNeighbours[i])
            {
                currentNeighbourPreference[0] = PreferenceEnum.Positive;
                IncreaseHappiness(_positiveNeighbourModifier);
            }
            else if (neighbourSlot2 != null && neighbourSlot2 == preferredNeighbours[i])
            {
                currentNeighbourPreference[1] = PreferenceEnum.Positive;
                IncreaseHappiness(_positiveNeighbourModifier);
            }

        }
        for (int i = 0;i < negativeNeighbours.Length; i++)
        {
            if (neighbourSlot1 != null && neighbourSlot1 == negativeNeighbours[i])
            {
                currentNeighbourPreference[0] = PreferenceEnum.Negative;
                DecreaseHappiness(_negativeNeighbourModifier);
            }
            else if (neighbourSlot2 != null && neighbourSlot2 == negativeNeighbours[i])
            {
                currentNeighbourPreference[1] = PreferenceEnum.Negative;
                DecreaseHappiness(_negativeNeighbourModifier);
            }
        }

        _horse.SetCurrentNeighbourPreference(currentNeighbourPreference[0], currentNeighbourPreference[1]);

    }

    private void DecreaseHappiness(int change)
    {
        _overallHorseHappiness -= change;
        if (_overallHorseHappiness < 0)
        {
            _overallHorseHappiness = 0;
        }
        else if(_overallHorseHappiness > 100)
        {
            _overallHorseHappiness = 100;
        }
    }
    private void IncreaseHappiness(int change)
    {
        _overallHorseHappiness += change;
        if (_overallHorseHappiness < 100)
        {
            _overallHorseHappiness = 100;
        }
        else if (_overallHorseHappiness < 0)
        {
            _overallHorseHappiness = 0;
        }
    }

}
