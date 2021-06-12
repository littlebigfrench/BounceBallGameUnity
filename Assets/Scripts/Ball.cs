using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject lastMultiplier;

    public GameManager gamemanager;
    private void Start()
    {
        gamemanager.BallInScnene++;
    }
    private void FixedUpdate()
    {
        Rigidbody2D rb = transform.gameObject.GetComponent<Rigidbody2D>();
        if (rb.velocity.y == 0 && rb.velocity.x == 0)
        {
            rb.velocity = new Vector2(0,4);
        }
    }
}
