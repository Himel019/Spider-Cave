using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int totalScenes;
    [SerializeField]
    private int totalGameLevels;
    
    void Awake() {
        MakeInstance();

        //PlayerPrefs.DeleteAll();

        if(!PlayerPrefs.HasKey("GameStartedFortheFirstTime")){
            for(int i = 0; i < totalGameLevels; i++) {
                string levelName = "Level " + i;
                PlayerPrefs.SetInt(levelName, 0);
            }
            PlayerPrefs.SetInt("Level 0", 1);
            PlayerPrefs.SetInt("GameStartedFortheFirstTime", 1);
        }
    }

    private void MakeInstance() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int levelIndex) {
        if(IsLevelUnlocked(levelIndex)) {
            SceneManager.LoadScene(levelIndex+2);
        }
    }

    public void LoadNextLevel() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(IsLevelUnlocked(currentSceneIndex - 1)){
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void ReloadLevel() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GoToMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void GoToLevelMenuScene() {
        SceneManager.LoadScene(1);
    }

    public void GoToGameCompleteScene() {
        SceneManager.LoadScene(6);
    }

    public void UnlockNextLevel(int levelIndex) {
        string levelName = "Level " + (levelIndex + 1);

        PlayerPrefs.SetInt(levelName, 1);
        Debug.Log(levelName + " Unlocked");
    }

    public bool IsLevelUnlocked(int levelIndex) {
        string levelName = "Level " + levelIndex;
        //Debug.Log(levelName);

        if(PlayerPrefs.GetInt(levelName) == 0) {
            return false;
        } else {
            //Debug.Log("working");
            return true;
        }
    }

    public int GetTotalGameLevels() {
        return totalGameLevels;
    }
}
