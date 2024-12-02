using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler instance;
    [Header("Sprites that appear at cursor")]
    [SerializeField] private GameObject atCursorLocation;
    [Space(7)]
    [SerializeField] private Animator checkAnimator;
    [SerializeField] private Image checkAtCursor;
    [SerializeField] private Sprite success;
    [SerializeField] private Sprite failure;
    [Space(7)]
    [SerializeField] private Animator foodAnimator;
    [SerializeField] private Image foodAtCursor;
    [Space(7)]
    [SerializeField] private Animator itemAnimator;
    [SerializeField] private Image itemAtCursor;
    [Space(3)]
    [Header("Foodbar")]
    [SerializeField] private Animator foodbarAnimator;
    [SerializeField] private List<Image> foodImages = new List<Image>();
    [SerializeField] private List<FoodTypeSO> foodSOs = new List<FoodTypeSO>();
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
    private void Start()
    {
        foodImages = new List<Image>();
        //Transform[] childs = foodbarAnimator.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in foodbarAnimator.gameObject.transform)
        {
            Debug.Log("child is: " + child);
            Image image = child.GetComponent<Image>();
            foodImages.Add(image);
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
        // int foodNumberToSet = FoodInventoryManager.Instance.GetFoodAmount(tempSlotData.data.horseFoodPreference);
        // foodNumberObjects[i].text = foodNumberToSet > 99 ? "99+" : foodNumberToSet.ToString();

        for (int i = 0; i < foodImages.Count; i++)
        {
            foodImages[i].sprite = foodSOs[i].foodSprite;

            int foodNumberToSet = FoodInventoryManager.Instance.GetFoodAmount(foodSOs[i]);
            TextMeshProUGUI foodText = foodImages[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            foodText.text = foodNumberToSet > 99 ? "99+" : foodNumberToSet.ToString();
        }

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
