using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string title;
    [SerializeField] private string flavourText;
    public void ActivatePopup()
    {
        PopupHandler.instance.DisplayPopup(sprite, title, flavourText);
    }
}
