using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float movementSpeed = -5.0f;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<GameController>();
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndZone")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            gameController.GameOver();
        }
    }

    private void Move()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
    }
}
