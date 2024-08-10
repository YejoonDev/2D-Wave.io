using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")] 
    [SerializeField] private float xMoveSpeed =2f;
    [SerializeField] private float xDelta =2f;
    private float _xStartPosition;
    
    [Header("Vertical Movement")] 
    [SerializeField] private float yMoveSpeed =0.5f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        float newX = _xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        _rigidbody2D.AddForce(Vector3.up * yMoveSpeed, ForceMode2D.Impulse);
    }
}
