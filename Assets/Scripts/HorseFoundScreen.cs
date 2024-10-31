using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HorseFoundScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject textBox;
    [SerializeField] private float waitTime;
    public static HorseFoundScreen instance;
    private bool isActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }
    public void StartPopup(ItemObject item)
    {
        if (!isActive)
        {
            StartCoroutine(TogglePopup(item.uiDisplay));
        }
    }

    public IEnumerator TogglePopup(Sprite horseSprite)
    {
        isActive = true;
        image.gameObject.SetActive(true);
        textObject.SetActive(true);
        textBox.SetActive(true);
        image.sprite = horseSprite;

        yield return new WaitForSeconds(waitTime);

        image.gameObject.SetActive(false);
        textObject.SetActive(false);
        textBox.SetActive(false);
        isActive = false;
    }
}
