using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectables : MonoBehaviour
{
    [SerializeField]
    private float timerBonus = 15f;
    [SerializeField]
    private float airBonus = 15f;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if(gameObject.name == "Air Collectable") {
                GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().SetTimer(airBonus);
            } else {
                GameObject.Find("Gameplay Controller").GetComponent<LevelTimer>().SetTimer(timerBonus);
            }
            Destroy(gameObject);
        }
    }
}
