using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler instance;
    [SerializeField] private Animator checkAnimator;
    [SerializeField] private Image checkAtCursor;
    [SerializeField] private Animator foodAnimator;
    [SerializeField] private Image foodAtCursor;
    [SerializeField] private Animator itemAnimator;
    [SerializeField] private Image itemAtCursor;
    [SerializeField] private Animator foodbarAnimator;
    [SerializeField] private GameObject atCursorLocation;
    [SerializeField] private Sprite success;
    [SerializeField] private Sprite failure;
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
    public void InteractionFeedback(bool isSuccess)
    {
        atCursorLocation.transform.position = Input.mousePosition;

        if (isSuccess)
        {
            checkAtCursor.sprite = success;
            checkAnimator.SetTrigger("Success");
        }
        else
        {
            checkAtCursor.sprite = failure;
            checkAnimator.SetTrigger("Failure");
        }
    }
    public void FoodFeedback(Sprite sprite)
    {
        foodAnimator.enabled = false;
        atCursorLocation.transform.position = Input.mousePosition;
        foodAtCursor.sprite = sprite;
        foodAnimator.enabled = true;
        foodAnimator.SetTrigger("ImageTooltip");
    }

    public void ShowFoods()
    {
        foodbarAnimator.SetTrigger("ShowFoods");
    }

    public void ItemFeedback(Sprite sprite, bool reversed)
    {
        itemAnimator.enabled = false;
        atCursorLocation.transform.position = Input.mousePosition;
        itemAtCursor.sprite = sprite;
        itemAnimator.enabled = true;
        if (reversed)
        {
            itemAnimator.SetTrigger("ItemTooltipReversed");
        }
        else
        {
            itemAnimator.SetTrigger("ItemTooltip");
        }
    }
}
