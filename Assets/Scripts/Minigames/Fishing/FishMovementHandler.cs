using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FishMovementHandler : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] protected float fishSpeed;
    private float targetXValue;
    private bool isMoving = false;
    private bool isMovingRight = false;

    protected float bobbingAmplitude;
    protected float bobbingFrequency;
    protected float originalYPosition;
    protected float bobbingOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (isMovingRight)
            {
                if (transform.position.x < targetXValue)
                {
                    transform.position += new Vector3(fishSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    Despawn();
                }
            }
            else
            {
                if (transform.position.x > targetXValue)
                {
                    transform.position -= new Vector3(fishSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    Despawn();
                }
            }

            float newY = originalYPosition + Mathf.Sin((Time.time + bobbingOffset) * bobbingFrequency) * bobbingAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    virtual public void Spawned(float spawnXValue, float newFishSpeed)
    {
        fishSpeed = newFishSpeed;
        originalYPosition = transform.position.y;
        SetRandomBobbing();

        if (spawnXValue == 10f) 
        {
            isMovingRight = false;
            spriteRenderer.flipX = true;
            targetXValue = -10f;
        }
        else
        {
            isMovingRight = true;
            spriteRenderer.flipX = false;
            targetXValue = 10f;
        }
        StartMoving();
    }

    private void StartMoving()
    {
        isMoving = true;
    }

    public void Caught()
    {
        StopMoving();
    }
    public void StopMoving()
    {
        isMoving = false;
    }

    public void Despawn()
    {
        Debug.Log("Fish despawned after reaching target.");
        Destroy(gameObject);
    }

    private void SetRandomBobbing()
    {
        bobbingAmplitude = Random.Range(0.2f, 0.4f);
        bobbingFrequency = Random.Range(0.7f, 3.3f);
        bobbingOffset = Random.Range(0f, Mathf.PI * 2);
    }

}
