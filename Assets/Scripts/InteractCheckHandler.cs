using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCheckHandler : MonoBehaviour
{
    public static InteractCheckHandler instance;
    [SerializeField] private Animator animator;
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
    public void RunAnimation(bool isSuccess)
    {
        animator.gameObject.transform.position = Input.mousePosition;
        animator.SetBool("ConditionMet", isSuccess);
    }
}
