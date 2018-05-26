using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public static int score = 0;
    public float movementSpeed = -5.0f;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent(typeof(UIManager)) as UIManager;
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
            //IncrementScore();
            uiManager.IncrementScore();
        }
    }

    private void IncrementScore()
    {
        score += 1;
        Debug.Log("Score: " + score);
    }
}
