using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public List<GameObject> spawnedObstacles = new List<GameObject>();
    public float obstacleSpeed;
    public float timerLength;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerLength / 2;
        spawnedObstacles.Clear();

        for (int i = 0; i < 6; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), transform.position.z - i * timerLength * obstacleSpeed);
            Quaternion randomRotation = new Quaternion(0, 0, 100, Random.Range(0, 360));
            GameObject spawnedObstacle = Instantiate(obstaclePrefab, randomPosition, randomRotation, transform);
            spawnedObstacles.Add(spawnedObstacle);
            Debug.Log("Starting obstacles spawned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLength)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), transform.position.z);
            Quaternion randomRotation = new Quaternion(0, 0, 100, Random.Range(0, 360));
            GameObject spawnedObstacle = Instantiate(obstaclePrefab, randomPosition, randomRotation, transform);
            spawnedObstacles.Add(spawnedObstacle);
            Debug.Log("Obstacle spawned");
            timer = 0;
        }

        foreach (GameObject obstacle in spawnedObstacles)
        {
            obstacle.transform.position -= new Vector3(0, 0, obstacleSpeed * Time.deltaTime);
            if (obstacle.transform.position.z < -1)
            {
                spawnedObstacles.Remove(obstacle);
                Destroy(obstacle);
            }
        }
    }
}
