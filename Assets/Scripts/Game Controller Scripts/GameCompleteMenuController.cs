using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteMenuController : MonoBehaviour
{
    public void GoBackToMainMenu() {
        GameManager.instance.GoToMenuScene();
    }
}
