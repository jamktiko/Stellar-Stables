using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationDelay : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string[] animTriggers;
    [SerializeField] private bool playRandomTrigger;
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
            if (IsAnimationFinished())
            {
                if (!playRandomTrigger)
                {
                    animator.SetTrigger(animTriggers[0]);
                }
                else
                {
                    int randomTriggerIndex = Random.Range(0, animTriggers.Length);
                    animator.SetTrigger(animTriggers[randomTriggerIndex]);
                }
            }

            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);

            StartCoroutine(RepeatAnimation());
        }
    }
    private bool IsAnimationFinished()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.normalizedTime >= 1 && !animator.IsInTransition(0);
    }
}
