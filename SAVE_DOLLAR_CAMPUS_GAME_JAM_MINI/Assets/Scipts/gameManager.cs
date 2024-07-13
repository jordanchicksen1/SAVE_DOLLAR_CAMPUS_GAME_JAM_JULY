using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public void pauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {

    }
}
