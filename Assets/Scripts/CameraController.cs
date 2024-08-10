using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 8f;
    
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    
    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }

}
