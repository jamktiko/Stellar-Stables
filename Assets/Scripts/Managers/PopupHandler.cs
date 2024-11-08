using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupHandler : MonoBehaviour
{
    public static PopupHandler instance;
    [SerializeField] private GameObject popupBox;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI flavourText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }

    public void DisplayPopup(Sprite img, string tit, string flav)
    {
        TogglePopup();
        image.sprite = img;
        title.text = tit;
        flavourText.text = flav;
    }

    public void TogglePopup()
    {
        popupBox.SetActive(!popupBox.activeInHierarchy);
    }
}
