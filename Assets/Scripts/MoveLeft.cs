using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    float groundLength;
    public float leftLimit;

    BoxCollider2D groundCollider;

    public static MoveLeft instance;

    private void Awake()
    {
        if(gameObject.CompareTag("Ground"))
        {
            groundCollider = GetComponent<BoxCollider2D>();
            groundLength = groundCollider.size.x;
        }

        instance = this;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if(gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundLength)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundLength, transform.position.y);
            }
        }

        if(gameObject.CompareTag("Column"))
        {
            if(transform.position.x <= leftLimit)
            {
                Destroy(gameObject);
            }
        }
    }
}
