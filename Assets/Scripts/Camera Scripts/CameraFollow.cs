using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            Vector3 temp = transform.position;
            temp.x = player.position.x;

            if(temp.x < minX) {
                temp.x = minX;
            } else if(temp.x > maxX) {
                temp.x = maxX;
            }

            temp.y = player.position.y;

            if(temp.y < minY) {
                temp.y = minY;
            } else if(temp.y > maxY) {
                temp.y = maxY;
            }

            transform.position = temp;
        }
    }
}
