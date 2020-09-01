using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AirTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    private GameplayController gameplayController;

    [SerializeField]
    private float air = 10f;
    [SerializeField]
    private float airBurn = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        GetReferences();
        gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null) {
            return;
        }

        if(air > 0) {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        } else {
            Destroy(player);
            gameplayController.PlayerDied();
        }
    }

    private void GetReferences() {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Air HUD Slider").GetComponent<Slider> ();

        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }

    public void SetTimer(float addTime) {
        air += addTime;
        slider.maxValue = air;
    }
}
