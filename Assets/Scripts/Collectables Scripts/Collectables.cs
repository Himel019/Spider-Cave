using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Door.instance != null) {
            int temp = Door.instance.GetCollectablesCount();
            Door.instance.SetCollectablesCount(++temp);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if(Door.instance != null) {
                Door.instance.DecrementCollectables();
            }
            Destroy(gameObject);
        }
    }
}
