using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HorseSO", menuName = "ScriptableObjects/HorseScriptableObject", order = 1)]

public class HorseSO : ScriptableObject
{

    [SerializeField] private GameObject _horsePrefab;
    [SerializeField] private string _horseName;
    [SerializeField] private int _horseLevel;
    [SerializeField] private int _horseHappiness;

    [SerializeField] private DecorTypeSO _decorationType;

    [SerializeField] private FoodTypeSO _foodType;

    [SerializeField] private HorseSO[] _preferredNeighbours;
    [SerializeField] private HorseSO[] _negativeNeighbours;
    private PreferenceEnum[] _currentNeighbourPreference = new PreferenceEnum[2] { PreferenceEnum.Neutral, PreferenceEnum.Neutral };

    public int GetHorseHappiness() { return _horseHappiness; }

    public int GetHorseLevel() { return _horseLevel; }

    public string GetHorseName() { return _horseName; }

    public HorseSO[] GetPreferredNeighbours() { return _preferredNeighbours; }

    public HorseSO[] GetNegativeNeighbours() { return _negativeNeighbours; }

    public void SetCurrentNeighbourPreference(PreferenceEnum neighbourSlot1, PreferenceEnum neighbourSlot2)
    {
        _currentNeighbourPreference[0] = neighbourSlot1;
        _currentNeighbourPreference[1] = neighbourSlot2;
    }

    public PreferenceEnum[] GetCurrentNeighbourPreference()
    {
        return _currentNeighbourPreference;
    }

    public FoodTypeSO GetFoodType() { return _foodType; }

    public DecorTypeSO GetDecorationType() { return _decorationType;}

}
