using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAdditionalAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animTrigger;
    public void PlayAnimation()
    {
        animator.SetTrigger(animTrigger);
    }
}
