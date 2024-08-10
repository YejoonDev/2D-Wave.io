using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Horizontal Movement")] 
    [SerializeField] private float xDelta;
    [SerializeField] private float xMoveSpeed;

    [Header("Vertical Movement")] 
    [SerializeField] private float yDelta;
    [SerializeField] private float yMoveSpeed;

    private Vector3 _startPosition;
    
    void Start()
    {
        _startPosition = transform.position;
    }
    
    
    void Update()
    {
        if (xMoveSpeed != 0)
        {
            float newX = _startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            
        }
        
        if (yMoveSpeed != 0)
        {
            float newY = _startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
