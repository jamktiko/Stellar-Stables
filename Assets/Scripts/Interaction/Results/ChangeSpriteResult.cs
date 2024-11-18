using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteResult : MonoBehaviour, IResult
{
    [SerializeField] private Image objectToChange;
    [SerializeField] private Sprite sprite;
    public void Execute()
    {
        objectToChange.sprite = sprite;
    }
}
