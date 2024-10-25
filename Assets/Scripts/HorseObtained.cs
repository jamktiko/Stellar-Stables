using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HorseObtained : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject textBox;
    public static HorseObtained instance;
    [SerializeField] private float waitTime;

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

    public IEnumerator TogglePopup(Sprite horseSprite)
    {
        image.gameObject.SetActive(true);
        textBox.SetActive(true);
        image.sprite = horseSprite;

        yield return new WaitForSeconds(waitTime);

        image.gameObject.SetActive(false);
        textBox.SetActive(false);
    }
}
