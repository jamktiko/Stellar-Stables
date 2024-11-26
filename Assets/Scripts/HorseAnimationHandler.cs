using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HorseAnimationHandler : MonoBehaviour
{

    public float timeBetweenFrames = 0.75f;
    public HorseAnimationSO horseAnimation;
    [SerializeField] private Image horseImage;
    private bool isPlaying;

    public void Play()
    {
        if (!isPlaying)
        {
            StartCoroutine(StartAnimation());
            isPlaying = true; 
        }
    }

    public void Stop()
    {
        if (isPlaying)
        {
            isPlaying = false;
            StopCoroutine(StartAnimation());
            if (horseAnimation.horseAnimationSprites.Length > 0)
            { 
                horseImage.sprite = horseAnimation.horseAnimationSprites[0];
            }
        }
    }

    private IEnumerator StartAnimation()
    {
        do
        {
            for (int i = 0; i < horseAnimation.horseAnimationSprites.Length; i++)
            {
                horseImage.sprite = horseAnimation.horseAnimationSprites[i];
                yield return new WaitForSeconds(timeBetweenFrames);
            } 
        } while (isPlaying);
    }

}
