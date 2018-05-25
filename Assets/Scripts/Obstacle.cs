using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float movementSpeed;

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

        }
    }

    private void Move()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
    }
}
