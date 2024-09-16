using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DecorTypeSO", menuName = "ScriptableObjects/DecorTypeScriptableObject", order = 1)]

public class DecorTypeSO : ScriptableObject
{

    [SerializeField] private GameObject _decorPrefab;
    [SerializeField] private string _decorName;

    public string GetDecorName() { return _decorName; }
    public GameObject GetDecorPrefab() { return _decorPrefab; }

}
