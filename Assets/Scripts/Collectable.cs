using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public static int score = 0;
    private float movementSpeed = -12.0f;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<GameController>();
    }

    void Update () {
        Move();
	}

    private void Move()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndZone" )
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameController.IncrementScore();
        }
    }

    private void IncrementScore()
    {
        score += 1;
        Debug.Log("Score: " + score);
    }
}
