using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private List<Transform> spawnPoints = new List<Transform>();
    private GameObject[] obstacles = new GameObject[numOfObstacles];
    public GameObject collectable;
    public GameObject obstaclesAndCollectablesParent;
    public float respawnSpeed = 2.0f;
    public float startRespawnTime = 2.0f;

    private static int numOfObstacles = 1;

    private void Start()
    {
        LoadSpawnPoints();
        LoadObstacles();
        InvokeRepeating("Spawn", startRespawnTime, respawnSpeed);
    }

    private void LoadSpawnPoints()
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

    public void Spawn()
    {
        int randomObstacleNum = UnityEngine.Random.Range(0, numOfObstacles);
        int newPosition = UnityEngine.Random.Range(0, spawnPoints.Count);
        SpawnRandomObstacle(randomObstacleNum, newPosition);

        newPosition = getFreeSpawn(newPosition);
        SpawnRandomCollectable(newPosition);
    }

    private int getFreeSpawn(int newPosition)
    {
        int temp;
        do
        {
            temp = UnityEngine.Random.Range(0, spawnPoints.Count);
            //Debug.Log("Spawner - temp: " + temp);
        } while (temp == newPosition);
        return temp;
    }

    private void SpawnRandomCollectable(int newPosition)
    {
        Instantiate(collectable, spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
    }

    //instantiate a randomly chosen obstacle in a randomly chosen spawn point
    private void SpawnRandomObstacle(int randomObstacleNum, int newPosition)
    {
        Instantiate(obstacles[randomObstacleNum], spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
    }

}
