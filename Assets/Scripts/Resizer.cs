using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private Vector3 _startSize;
    [SerializeField] private Vector3 endSize;
    [SerializeField] private float resizeTime;

    private IEnumerator Start()
    {
        _startSize = transform.localScale;
        while (true)
        {
            yield return StartCoroutine(Resize(_startSize, endSize));
            yield return StartCoroutine(Resize(endSize, _startSize));
        }
    }

    private IEnumerator Resize(Vector3 start, Vector3 end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / resizeTime;
            transform.localScale = Vector3.Lerp(start, end, percent);
            yield return null;
        }
    }
}
