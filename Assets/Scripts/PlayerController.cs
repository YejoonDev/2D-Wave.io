using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageController stageController;
    private Movement2D _movement2D;

    private void Awake()
    {
        _movement2D = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        if (stageController.IsGameOver == true)
            return;
        
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
            stageController.IncreaseScore(1);
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(GetComponent<Rigidbody2D>());
            stageController.GameOver();
        }
    }
}
