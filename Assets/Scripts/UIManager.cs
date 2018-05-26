using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text currentPlayingScorePreview;
    public Text currentGameOverScorePreview;
    public Text highscorePreview;

    public GameObject backgroundGray;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    // Use this for initialization
    void Start () {
        currentPlayingScorePreview.text = "" + 0;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        backgroundGray.SetActive(false);
    }

    internal void SetCurrentPlayingScore(int currentScore)
    {
        currentPlayingScorePreview.text = "" + currentScore;
    }

    public void ShowGameOverScreen()
    {
        if (!backgroundGray.activeInHierarchy)
        {
            backgroundGray.SetActive(true);
        }
        if (!gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ShowPausedScreen()
    {
        if (!backgroundGray.activeInHierarchy)
        {
            backgroundGray.SetActive(true);
        }
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
    }

    public void HidePanels()
    {
        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
        }
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }
        if (backgroundGray.activeInHierarchy)
        {
            backgroundGray.SetActive(false);
        }
    }

    public void SetGameOverScores(int highscore, int currentScore)
    {
        currentGameOverScorePreview.text = "New score\n" + currentScore;
        highscorePreview.text = "Highscore\n" + highscore;
    }
}
