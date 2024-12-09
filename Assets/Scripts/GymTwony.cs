using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymTwony : MonoBehaviour
{
    public Image image;
    public Animator animator;
    public GetHorseResult getHorse;
    public int twonyLevel;
    public bool hasBeenCollected;
    private void Start()
    {
        twonyLevel = MinigameLevelManager.Instance.TwonyLevelIndex;
        if ((twonyLevel - 1) > 0 && MinigameLevelManager.Instance.TwonyLevelIndex < 4)
        {
            animator.enabled = false;
            image.sprite = getHorse.horseSO[twonyLevel - 1].uiDisplay;
        }
        else if (twonyLevel >= 4)
        {
            gameObject.SetActive(false);
        }
    }
    public void CollectTwony()
    {
        if (MinigameLevelManager.Instance.TwonyLevelIndex < 4 && !hasBeenCollected)
        {
            hasBeenCollected = true;
            MinigameLevelManager.Instance.TwonyLevelIndex++;
            getHorse.Execute(twonyLevel-1);
        }
        else
        {
            Debug.Log("max twony lvl");
        }
    }
}
