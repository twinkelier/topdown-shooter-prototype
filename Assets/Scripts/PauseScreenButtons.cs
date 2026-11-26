using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScreenButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject blur;
    [SerializeField] private GameManager gameManager;
    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseButtons.SetActive(false);
        blur.SetActive(false);
        gameManager.shootingEnabled = true;
        gameManager.slowedDown = false;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
