using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HorseFoundScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private HorseAnimationHandler animationHandler;
    [SerializeField] private HorseAnimationSO horseAnimation;
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
            Destroy(this.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }
    public void StartPopup(ItemObject item)
    {
        if (!isActive)
        {
            if (item.data.horseAnimation != null)
            {
                StartCoroutine(TogglePopup(item.uiDisplay, item.data.horseAnimation)); 
            }
            else
            {
                StartCoroutine(TogglePopup(item.uiDisplay));
            }
        }
    }

    public IEnumerator TogglePopup(Sprite horseSprite)
    {
        if (isActive) yield break;
        isActive = true;
        horseAnimation = null;
        image.gameObject.SetActive(true);
        textObject.SetActive(true);
        textBox.SetActive(true);
        image.sprite = horseSprite;

        StableHappinessManager.Instance.IsStablesFilled = true;

        yield return new WaitForSecondsRealtime(waitTime);

        image.gameObject.SetActive(false);
        textObject.SetActive(false);
        textBox.SetActive(false);
        isActive = false;
    }

    public IEnumerator TogglePopup(Sprite horseSprite, HorseAnimationSO inputAnimation)
    {
        if (isActive) yield break;
        isActive = true;
        horseAnimation = inputAnimation;
        image.gameObject.SetActive(true);
        textObject.SetActive(true);
        textBox.SetActive(true);
        image.sprite = horseSprite;
        if (horseAnimation.horseAnimationSprites.Length > 0)
        {
            animationHandler.horseAnimation = horseAnimation;
            animationHandler.Play();
        }

        StableHappinessManager.Instance.IsStablesFilled = true;

        yield return new WaitForSecondsRealtime(waitTime);

        if (horseAnimation.horseAnimationSprites.Length > 0)
        {
            animationHandler.Stop();
            animationHandler.horseAnimation = null;
        }
        image.gameObject.SetActive(false);
        textObject.SetActive(false);
        textBox.SetActive(false);
        isActive = false;
    }

}
