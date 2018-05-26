using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scorePreview;
    public int currentScore;

    //public GameObject pausePanel;

	// Use this for initialization
	void Start () {
        scorePreview.text = "" + 0;
	}
	
    public void IncrementScore()
    {
        currentScore++;
        scorePreview.text = "" + currentScore;
    }
}
