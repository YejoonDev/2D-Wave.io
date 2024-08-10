using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] areaPrefabs;
    [SerializeField] private int areaCountAtStart = 2;
    [SerializeField] private int distanceToNext = 30;
    private int _areaIdx;
    
    private void Awake()
    {
        // 초기생성 
        for (int i = 0; i < areaCountAtStart; i++)
        {
            SpawnArea();
        }
    }

    private void Update()
    {
        // 게임 중 생성
        int playerIdx = (int)(player.position.y / distanceToNext);

        if (playerIdx == _areaIdx - 1)
        {
            SpawnArea();
        }
    }

    private void SpawnArea()
    {
        int idx = Random.Range(0, areaPrefabs.Length);
        GameObject clone = Instantiate(areaPrefabs[idx]);
        clone.transform.position = Vector3.up * distanceToNext * _areaIdx;
        _areaIdx++;
    }
}
