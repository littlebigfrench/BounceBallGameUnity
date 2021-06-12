using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollider : MonoBehaviour
{
    public GameManager gamemanager;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Ball>())
        {
            gamemanager.NumberOfBalls++;
            gamemanager.BallInScnene--;
            Destroy(collider.gameObject);
        }
    }
}
