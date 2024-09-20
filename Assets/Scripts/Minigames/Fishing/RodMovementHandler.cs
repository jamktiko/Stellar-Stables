using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMovementHandler : MonoBehaviour
{

    [SerializeField] private RectTransform _rodTransform;
    [SerializeField] private float _rodSpeed;
    private Vector3 _rodPosition;

    private bool _isHoldingClick = false;

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


        if (_isHoldingClick)
        {
            if (transform.position.y > -1.2f)
            {
                transform.position -= new Vector3(0, _rodSpeed * Time.deltaTime*1.5f, 0);
            }
        }
        else
        {
            if (transform.position.y < 8f)
            {
                transform.position += new Vector3(0, _rodSpeed * Time.deltaTime, 0);
            }
        }
        
    }
}
