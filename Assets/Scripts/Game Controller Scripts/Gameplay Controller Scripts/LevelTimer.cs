using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;

    [SerializeField]
    private float timer = 10f;
    [SerializeField]
    private float timerBurn = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) {
            return;
        }

        if(timer > 0) {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        } else {
            Destroy(player);
        }
    }

    private void GetReferences() {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Timer HUD Slider").GetComponent<Slider> ();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }

    public void SetTimer(float addTime) {
        timer += addTime;
        slider.maxValue = timer;
    }
}
