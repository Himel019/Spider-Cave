using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AirTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;

    [SerializeField]
    private float air = 10f;
    [SerializeField]
    private float airBurn = 1f;

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

        if(air > 0) {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        } else {
            Destroy(player);
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
