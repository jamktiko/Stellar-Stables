using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{

    [SerializeField] private float speedMin;
    [SerializeField] private float speedMax;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        transform.localScale = transform.localScale * Random.Range(0.65f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
    }
}
