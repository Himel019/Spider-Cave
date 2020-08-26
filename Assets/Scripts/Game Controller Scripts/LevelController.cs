using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lockPanel;

    void Start() {
        for(int i = 0; i < GameManager.instance.GetTotalGameLevels(); i++) {
            if(GameManager.instance.IsLevelUnlocked(i)) {
                lockPanel[i].SetActive(false);
                //Debug.Log("Running");
            }
        }
    }

    public void StartLevel(int levelIndex) {
        GameManager.instance.LoadLevel(levelIndex);
    }

    public void BackToMenu() {
        GameManager.instance.GoToMenuScene();
    }
}
