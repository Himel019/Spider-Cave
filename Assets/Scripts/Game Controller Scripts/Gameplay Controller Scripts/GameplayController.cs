using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Button resumeGame;
    [SerializeField]
    private Button restartGame;

    public void PauseGame() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.gameObject.SetActive(true);
        restartGame.gameObject.SetActive(false);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("3_Gameplay");
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1_MainMenu");
    }

    public void PlayerDied() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.gameObject.SetActive(false);
        restartGame.gameObject.SetActive(true);
    }    
}
