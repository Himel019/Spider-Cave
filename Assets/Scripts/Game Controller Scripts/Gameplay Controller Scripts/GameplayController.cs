using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private int currentLevelNum;

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Button resumeGame;
    [SerializeField]
    private Button restartGame;
    [SerializeField]
    private Button nextLevelButton;

    public void PauseGame() {
        if(!pausePanel.activeInHierarchy) {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            resumeGame.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
        }
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        GameManager.instance.ReloadLevel();
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        GameManager.instance.GoToMenuScene();
    }

    public void PlayerDied() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.gameObject.SetActive(false);
        restartGame.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(false);
    }

    public void LevelComplete() {
        Time.timeScale = 0f;

        if(currentLevelNum == GameManager.instance.GetTotalGameLevels()) {
            GameManager.instance.GoToGameCompleteScene();
        } else if(currentLevelNum < GameManager.instance.GetTotalGameLevels()) {
            GameManager.instance.UnlockNextLevel(SceneManager.GetActiveScene().buildIndex-2);

            pausePanel.SetActive(true);
            resumeGame.gameObject.SetActive(false);
            restartGame.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(true);
        }
    }

    public void GoToNextLevel() {
        Time.timeScale = 1f;
        if(currentLevelNum < GameManager.instance.GetTotalGameLevels()) {
            GameManager.instance.LoadNextLevel();
        } else {
            GameManager.instance.GoToGameCompleteScene();
        }
    }    
}
