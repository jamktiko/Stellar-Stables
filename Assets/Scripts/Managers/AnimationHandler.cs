using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler instance;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject location;
    [SerializeField] private Image imageAtCursor;
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
        location.transform.position = Input.mousePosition;

        if (isSuccess)
        {
            imageAtCursor.sprite = success;
            animator.SetTrigger("Success");
        }
        else
        {
            imageAtCursor.sprite = failure;
            animator.SetTrigger("Failure");
        }
    }
    public void FoodFeedback(Sprite sprite)
    {
        animator.enabled = false;

        location.transform.position = Input.mousePosition;
        Debug.Log($"sprite is: {sprite}");
        
        imageAtCursor.sprite = sprite;
        animator.enabled = true;
        animator.SetTrigger("ImageTooltip");
    }

    public void ShowFoods()
    {
        animator.SetTrigger("ShowFoods");
    }
}
