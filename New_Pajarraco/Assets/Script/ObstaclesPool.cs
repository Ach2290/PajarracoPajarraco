using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject obtacle;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;

    private float timeElapsed;
    private int obstacleCount;
    private GameObject[] obstacles;

    void Start()
    {
        obstacles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obtacle);
            obstacles[i].SetActive(false);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTime && !GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
        }
    }
    private void SpawnObstacle()
    {
        timeElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new  Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if (!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
        }

       
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
