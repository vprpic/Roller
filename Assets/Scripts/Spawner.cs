using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private List<Transform> spawnPoints = new List<Transform>();
    private List<Transform> environmentSpawnPoints = new List<Transform>();
    private GameObject[] obstacles = new GameObject[numOfObstaclePrefabs];
    private GameObject[] environment = new GameObject[numOfEnvironmentPrefabs];
    public GameObject collectable;
    public GameObject obstaclesAndCollectablesParent;
    public GameObject environmentSpawnParent;
    public GameObject obstacleSpawnParent;
    public float respawnSpeed = 2.0f;
    public float startRespawnTime = 1.0f;

    //manually inputed number of prefabs in the obstacles folder
    private static int numOfObstaclePrefabs = 4;
    private static int numOfEnvironmentPrefabs = 5;

    private void Start()
    {
        environmentSpawnPoints = LoadEnvironmentSpawnPoints(environmentSpawnParent.gameObject);
        spawnPoints = LoadEnvironmentSpawnPoints(obstacleSpawnParent.gameObject);

        LoadObstaclePrefabs();
        LoadEnvironmentPrefabs();
        InvokeRepeating("Spawn", startRespawnTime, respawnSpeed);
        InvokeRepeating("SpawnEnvironment", startRespawnTime * 2, respawnSpeed / 2.0f);
    }

    private List<Transform> LoadEnvironmentSpawnPoints(GameObject spawnParent)
    {
        Transform[] tempSpawnPoints = spawnParent.GetComponentsInChildren<Transform>();
        List<Transform> tempSpawnList = new List<Transform>();
        foreach (Transform child in tempSpawnPoints)
        {
            if (child.parent != transform.parent)
            {
                tempSpawnList.Add(child);
            }
        }
        return tempSpawnList;
    }

    //private void LoadSpawnPoints()
    //{
    //    Transform[] tempSpawnPoints = this.gameObject.GetComponentsInChildren<Transform>();
    //    foreach (Transform child in tempSpawnPoints)
    //    {
    //        if (child.parent != transform.parent)
    //        {
    //            spawnPoints.Add(child);
    //        }
    //    }
    //}

    private void LoadEnvironmentPrefabs()
    {
        for (int o = 0; o < numOfEnvironmentPrefabs; o++)
        {
            environment[o] = Resources.Load("Prefabs/Environment/Environment" + o) as GameObject;
        }
    }

    public void LoadObstaclePrefabs()
    {
        for (int o = 0; o < numOfObstaclePrefabs; o++)
        {
            obstacles[o] = Resources.Load("Prefabs/Obstacles/Obstacle" + o) as GameObject;
        }
    }

    public void Spawn()
    {
        List<bool> spawnTaken = PrepareSpawnList(spawnPoints.Count);
        SpawnRandomObstacle(spawnTaken);
        if (UnityEngine.Random.Range(0, 9) < 5)
        {
            SpawnRandomCollectable(spawnTaken);
        }
    }

    public void SpawnEnvironment()
    {
        List<bool> spawnEnvironmentTaken = PrepareSpawnList(environmentSpawnPoints.Count);
        SpawnRandomEnvironment(spawnEnvironmentTaken);
        //SpawnRandomEnvironment(spawnEnvironmentTaken);
        //SpawnRandomEnvironment(spawnEnvironmentTaken);
        //SpawnRandomEnvironment(spawnEnvironmentTaken);
    }

    private void SpawnRandomEnvironment(List<bool> spawnEnvironmentTaken)
    {
        int newPosition = FindNewSpawn(spawnEnvironmentTaken, environmentSpawnPoints.Count);
        int randomEnvironmentNum = GetRandomFromRange(numOfEnvironmentPrefabs);
        if (newPosition != -1)
        {
            Instantiate(environment[randomEnvironmentNum], environmentSpawnPoints[newPosition].position, environmentSpawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
        }
    }

    private List<bool> PrepareSpawnList(int numOfSpawn)
    {
        List<bool> spawnTaken = new List<bool>();
        for (int i = 0; i < numOfSpawn; i++)
        {
            spawnTaken.Add(false);
        }
        return spawnTaken;
    }

    private void SpawnRandomCollectable(List<bool> spawnTaken)
    {
        //TODO: make more types of collectables - moving laser or smt
        int newPosition = FindNewSpawn(spawnTaken, spawnPoints.Count);
        if (newPosition != -1)
        {
            Instantiate(collectable, spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
        }
    }

    private void SpawnRandomObstacle(List<bool> spawnTaken)
    {
        int newPosition = FindNewSpawn(spawnTaken, spawnPoints.Count);
        int randomObstacleNum = GetRandomFromRange(numOfObstaclePrefabs);
        if(newPosition != -1)
        {
            Instantiate(obstacles[randomObstacleNum], spawnPoints[newPosition].position, spawnPoints[newPosition].rotation, obstaclesAndCollectablesParent.transform);
        }
    }

    private int GetRandomFromRange(int maxNum)
    {
        return UnityEngine.Random.Range(0, maxNum);
    }

    private int FindNewSpawn(List<bool> spawnTaken, int numOfSpawns)
    {
        int newPosition = -1;

        if (spawnTaken.Contains(false))
        {
            do
            {
                newPosition = UnityEngine.Random.Range(0, numOfSpawns);
            } while (spawnTaken[newPosition]);
        }
        spawnTaken[newPosition] = true;
        return newPosition;
    }
}
