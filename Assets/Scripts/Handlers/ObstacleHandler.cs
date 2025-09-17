using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;
    [SerializeField]
    private GameHandler _gameHandler;
    [SerializeField]
    private float obstacleSpeed;
    [SerializeField]
    private float timerLength;
    private float timer;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerLength / 2;
        spawnedObstacles.Clear();

        SpawnObstacles(3);
        Debug.Log("Starting obstacles spawned");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLength)
        {
            SpawnObstacles(1);
        }

        foreach (GameObject obstacle in spawnedObstacles)
        {
            obstacle.transform.position -= new Vector3(0, 0, obstacleSpeed * Time.deltaTime);
            if (obstacle.transform.position.z < -obstacle.transform.localScale.z)
            {
                RemoveObstacle(obstacle);
            }
        }
    }
    void SpawnObstacles(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int randomGap = Random.Range(0, 8);

            for (int j = 0; j < 9; j++)
            {
                if (j == randomGap) continue;

                Vector3 spawnPosition = new Vector3(j / 3 * 3 - 3f, j % 3 * 3 - 3f, transform.position.z - i * timerLength * obstacleSpeed);
                GameObject spawnedObstacle = Instantiate(_obstaclePrefab, spawnPosition, transform.rotation, transform);
                spawnedObstacles.Add(spawnedObstacle);
                Debug.Log("Obstacle spawned");
                timer = 0;
            }
            
        }
    }

    void RemoveObstacle(GameObject obstacle)
    {
        spawnedObstacles.Remove(obstacle);
        Destroy(obstacle);
    }

}