using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablesScroller : MonoBehaviour
{
    public static StablesScroller instance;
    [SerializeField] private float scrollSpeed = 200f;
    [SerializeField] private float buttonSpeed = 100f;
    [SerializeField] private float smoothness = 0.2f;
    [SerializeField] private float maxY;
    private RectTransform interfaceTransform;
    private float minY;
    private float targetPositionY;
    private float currentVelocity;
    private bool isHeldUp;
    private bool isHeldDown;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }
    private void Start()
    {
        interfaceTransform = DynamicInterface.instance.GetComponent<RectTransform>();
        targetPositionY = interfaceTransform.anchoredPosition.y;
        minY = interfaceTransform.anchoredPosition.y;
    }
    public void ResetInterfacePosition()
    {
        interfaceTransform.anchoredPosition = Vector2.zero;
        targetPositionY = 0f;
        currentVelocity = 0f;
        //Debug.Log("StablesScroller ran thang.");
    }
    private void Update()
    {
        ProcessScrollInput();
        MoveInterface();
        MoveUp();
        MoveDown();
    }
    public void OnHeldUp()
    {
        isHeldUp = true;
    }
    public void OnReleaseUp()
    {
        isHeldUp = false;
    }
    public void OnHeldDown()
    {
        isHeldDown = true;
    }
    public void OnReleaseDown()
    {
        isHeldDown = false;
    }
    public void MoveUp()
    {
        if (isHeldUp)
        {
            targetPositionY = Mathf.Clamp(targetPositionY + buttonSpeed, minY, maxY);
        }
    }
    public void MoveDown()
    {
        if (isHeldDown)
        {
            targetPositionY = Mathf.Clamp(targetPositionY - buttonSpeed, minY, maxY);
        }
    }
    private void ProcessScrollInput()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            targetPositionY += -scrollInput * scrollSpeed;
            targetPositionY = Mathf.Clamp(targetPositionY, minY, maxY);
        }
    }
    private void MoveInterface()
    {
        if (Mathf.Abs(interfaceTransform.anchoredPosition.y - targetPositionY) < 0.1f)
        {
            currentVelocity = 0f;
            interfaceTransform.anchoredPosition = new Vector2(interfaceTransform.anchoredPosition.x, targetPositionY);
        }
        else
        {
            float newPositionY = Mathf.SmoothDamp(interfaceTransform.anchoredPosition.y, targetPositionY, ref currentVelocity, smoothness);
            interfaceTransform.anchoredPosition = new Vector2(interfaceTransform.anchoredPosition.x, newPositionY);
        }


        //float newPositionY = Mathf.SmoothDamp(interfaceTransform.anchoredPosition.y, targetPositionY, ref currentVelocity, smoothness);
        //interfaceTransform.anchoredPosition = new Vector2(interfaceTransform.anchoredPosition.x, newPositionY);
    }
}
