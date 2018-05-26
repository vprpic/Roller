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

    //manually inputed number of prefabs in the obstacles folder
    private static int numOfObstacles = 2;

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
        }
    }

    public void Spawn()
    {
        List<bool> spawnTaken = PrepareSpawnList();
        //TODO: remember last few locations and avoid respawning at that spawn
        //TODO: obstacles with 2 spawn points
        SpawnRandomObstacle(spawnTaken);
        //SpawnRandomObstacle(spawnTaken);
        if (UnityEngine.Random.Range(0, 9) < 5)
        {
            SpawnRandomCollectable(spawnTaken);
        }
    }

    private List<bool> PrepareSpawnList()
    {
        List<bool> spawnTaken = new List<bool>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnTaken.Add(false);
        }
        return spawnTaken;
    }

    private void SpawnRandomCollectable(List<bool> spawnTaken)
    {
        //TODO: make more types of collectables - moving laser or smt
        int newPosition = FindNewSpawn(spawnTaken);
        if (newPosition != -1)
        {
            Instantiate(collectable, spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
        }
    }

    private void SpawnRandomObstacle(List<bool> spawnTaken)
    {
        int newPosition = FindNewSpawn(spawnTaken);
        int randomObstacleNum = FindNewObstacle();
        if(newPosition != -1)
        {
            Instantiate(obstacles[randomObstacleNum], spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
        }
    }

    private int FindNewObstacle()
    {
        return UnityEngine.Random.Range(0, numOfObstacles);
    }

    private int FindNewSpawn(List<bool> spawnTaken)
    {
        int newPosition = -1;

        if (spawnTaken.Contains(false))
        {
            do
            {
                newPosition = UnityEngine.Random.Range(0, spawnPoints.Count);
            } while (spawnTaken[newPosition]);
        }
        spawnTaken[newPosition] = true;
        return newPosition;
    }
}
