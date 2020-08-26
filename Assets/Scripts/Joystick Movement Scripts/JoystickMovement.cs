using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class JoystickMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player> ();
        GameObject.Find("Jump Button").GetComponent<Button>().onClick.AddListener(() => PlayerJump());
    }

    public void OnPointerDown(PointerEventData data) {
        if(gameObject.name == "Left Button") {
            player.SetMoveLeft(true);
        } else {
            player.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data) {
        player.StopMoving();
    }

    public void PlayerJump() {
        player.Jump();
    }
}
