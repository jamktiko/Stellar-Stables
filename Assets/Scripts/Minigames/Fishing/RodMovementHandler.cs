using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMovementHandler : MonoBehaviour
{

    public static RodMovementHandler Instance { get; private set; }

    [SerializeField] private RectTransform _rodTransform;
    [SerializeField] private float _rodSpeed;
    [SerializeField] private Animator animator;
    //[SerializeField] private Animation flashAnimation;
    private Vector3 _rodPosition;

    private bool _isReset = false;
    private bool _isHoldingClick = false;

    public event Action OnRodReset;
    public event Action OnRodEnable;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isHoldingClick = true;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _isHoldingClick = false;
        }


        if (_isHoldingClick && !_isReset)
        {
            if (transform.position.y > 0f)
            {
                transform.position -= new Vector3(0, _rodSpeed * Time.deltaTime*1.5f, 0);
            }
            else if (transform.position.y <= 0f)
            {
                Punish();
            }
        }
        else
        {
            if (transform.position.y < 9.25f)
            {
                transform.position += new Vector3(0, _rodSpeed * Time.deltaTime, 0);
            }
        }
        
    }

    private void Punish()
    {
        _isHoldingClick = false;
        _isReset = true;
        animator.SetTrigger("Flash");
        _rodSpeed *= 2;
        OnRodReset?.Invoke();
        //flashAnimation.Play();
    }

    public void EnableRod()
    {
        _rodSpeed /= 2;
        _isReset = false;
        OnRodEnable?.Invoke();
    }

}
