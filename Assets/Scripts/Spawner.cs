using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private List<Transform> spawnPoints = new List<Transform>();
    private GameObject[] obstacles = new GameObject[numOfObstacles];
    public GameObject obstaclesParent;
    public float respawnSpeed = 2.0f;
    public float startRespawnTime = 2.0f;

    private static int numOfObstacles = 1;

    private void Start()
    {
        loadSpawnPoints();
        LoadObstacles();
        InvokeRepeating("SpawnRandomObstacle", startRespawnTime, respawnSpeed);
    }

    private void loadSpawnPoints()
    {
        Transform[] tempSpawnPoints = this.GetComponentsInChildren<Transform>();
        foreach (Transform child in tempSpawnPoints)
        {
            if (child.parent != transform.parent)
            {
                spawnPoints.Add(child);
            }
        }
    }

    public void LoadObstacles()
    {
        for (int o = 0; o < numOfObstacles; o++)
        {
            obstacles[o] = Resources.Load("Prefabs/Obstacles/Obstacle" + o) as GameObject;
            Debug.Log("Prefabs/Obstacles/Obstacle" + o);
        }
    }

    //instantiate a randomly chosen obstacle in a randomly chosen spawn point
    public void SpawnRandomObstacle()
    {
        int randomObstacleNum = UnityEngine.Random.Range(0, numOfObstacles);
        int newPosition = UnityEngine.Random.Range(0, spawnPoints.Count);  

        Instantiate(obstacles[randomObstacleNum], spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesParent.transform);
    }

}
