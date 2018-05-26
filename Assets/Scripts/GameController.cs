using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private UIManager uIManager;
    private TapTest tapTest;
    private Player player;
    private int currentPlayingScore;

    public float timeScale;
    private bool paused;

    void Start () {
        uIManager = GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<UIManager>();
        tapTest = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<TapTest>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>();
        timeScale = 1.0f;
        paused = false;
    }
	
	void Update () {
        if (tapTest.Tap)
        {
            if(!paused)
            {
                if (player.goLeft)
                {
                    player.goLeft = false;
                }
                else
                {
                    player.goLeft = true;
                }
            }
            else
            {
                StartGame();
            }
        }
    }

    public void GameOver()
    {
        PauseTime();
        uIManager.ShowGameOverScreen();
        UpdateHighscore(currentPlayingScore);
        uIManager.SetGameOverScores(PlayerPrefs.GetInt("Highscore"), currentPlayingScore);
    }

    private void UpdateHighscore(int currentPlayingScore)
    {
        if (PlayerPrefs.GetInt("Highscore") < currentPlayingScore)
        {
            PlayerPrefs.SetInt("Highscore", currentPlayingScore);
            PlayerPrefs.Save();
        }
    }

    private void PauseTime()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0.0f;
        }
    }

    public void StartGame()
    {
        currentPlayingScore = 0;
        uIManager.SetCurrentPlayingScore(currentPlayingScore);
        uIManager.HidePanels();
        SceneManager.LoadSceneAsync(0);
        StartTime();
    }

    private void StartTime()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = timeScale;
        }
    }

    public void IncrementScore()
    {
        currentPlayingScore++;
        uIManager.SetCurrentPlayingScore(currentPlayingScore);
    }

}
