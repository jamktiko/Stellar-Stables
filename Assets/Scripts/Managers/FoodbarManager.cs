using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FoodbarManager : MonoBehaviour
{
    public static FoodbarManager instance;

    [SerializeField] private Animator foodbarAnimator;
    [SerializeField] private List<Image> foodImages = new List<Image>();
    [SerializeField] private List<FoodTypeSO> foodSOs = new List<FoodTypeSO>();
    private bool isDown;
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
        foreach (Transform child in foodbarAnimator.gameObject.transform)
        {
            //Debug.Log("child is: " + child);
            Image image = child.GetComponent<Image>();
            foodImages.Add(image);
        }
    }
    public void ToggleFoodbar()
    {
        if (!isDown)
        {
            UpdateFoodStatus();
            foodbarAnimator.SetTrigger("ShowFoods");
            isDown = true;
        }
        else
        {
            UpdateFoodStatus();
            foodbarAnimator.SetTrigger("HideFoods");
            isDown = false;
        }
    }
    public void UpdateFoodStatus()
    {
        for (int i = 0; i < foodImages.Count; i++)
        {
            foodImages[i].sprite = foodSOs[i].foodSprite;

            int foodNumberToSet = FoodInventoryManager.Instance.GetFoodAmount(foodSOs[i]);
            TextMeshProUGUI foodText = foodImages[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            foodText.text = foodNumberToSet > 99 ? "99+" : foodNumberToSet.ToString();
        }
    }
}
