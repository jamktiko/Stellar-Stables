using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationDelay : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 5f;
    private void Start()
    {
        animator = GetComponent<Animator>();

        BeginAnimationLoop();
    }
    private void OnEnable()
    {
        BeginAnimationLoop();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void BeginAnimationLoop()
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(StartAnimation), randomDelay);
    }
    private void StartAnimation()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(RepeatAnimation());
        }
    }
    private IEnumerator RepeatAnimation()
    {
        {
            animator.SetTrigger("GetWiggling");

            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);

            StartCoroutine(RepeatAnimation());
        }
    }
}
