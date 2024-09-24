using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FishMovementHandler : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float fishSpeed;
    private float targetXValue;
    private bool isMoving = false;
    private bool isMovingRight = false;

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
        }
    }

    public void Spawned(float spawnXValue, float newFishSpeed)
    {
        fishSpeed = newFishSpeed;
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
        if (gameObject.name.Contains("Crab"))
        {
            transform.position = new Vector3(spawnXValue, -4.58f, 0f);
            fishSpeed /= 1.5f;
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

}
