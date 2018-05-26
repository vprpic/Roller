using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotationSpeed;
    public TapTest tapTest;
    public Transform LeftSpot;
    public Transform RightSpot;
    public float speed = 5;

    private bool goLeft; 

	void Start () {
        goLeft = true;
	}
	
	void Update () {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        if (tapTest.Tap)
        {
            if(goLeft)
            {
                goLeft = false;
            }
            else
            {
                goLeft = true;
            }
        }
        if(goLeft)
        {
            MoveLeft();
        }
        else if(!goLeft)
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, LeftSpot.position, speed * Time.deltaTime);
    }

    private void MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, RightSpot.position, speed * Time.deltaTime);
    }
}
