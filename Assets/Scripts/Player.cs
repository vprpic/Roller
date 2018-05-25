using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotationSpeed;
    public TapTest tapTest;
    
	void Start () {
	}
	
	void Update () {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        if (tapTest.Tap)
        {
            Debug.Log("Tap!");
        }
    }
}
