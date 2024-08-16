using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 8f;
    
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }

    public void ChangeBackgroundColor()
    {
        float colorHue = Random.Range(0, 10);
        colorHue *= 0.1f;
        _mainCamera.backgroundColor = 
            Color.HSVToRGB(colorHue, 0.6f, 0.8f);
    }

    public void ShakeCamera(float shakeTime, float shakeIntensity)
    {
        StartCoroutine(ShakeCameraRoutine(shakeTime, shakeIntensity));
    }

    private IEnumerator ShakeCameraRoutine(float shakeTime, float shakeIntensity)
    {
        Vector3 startRotation = transform.eulerAngles;

        while (shakeTime > 0.0f)
        {
            float x = 0;
            float y = 0;
            float z = Random.Range(-1f, 1f);

            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity);
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.Euler(startRotation);
    }
}
