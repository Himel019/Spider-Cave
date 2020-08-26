using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    private GameplayController gameplayController;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameplayController.PlayerDied();
        }

        if(other.tag == "Ground" || other.tag == "Platforms") {
            Destroy(gameObject);
        }
    }
}
