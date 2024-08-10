using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D _movement2D;

    private void Awake()
    {
        _movement2D = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        _movement2D.MoveToX();

        if (Input.GetMouseButton(0))
        {
            _movement2D.MoveToY();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Score + 1");
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }
    }
}
