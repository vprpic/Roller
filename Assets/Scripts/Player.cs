using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotationSpeed;
    
	void Start () {
	}
	
	void Update () {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
	}
}
