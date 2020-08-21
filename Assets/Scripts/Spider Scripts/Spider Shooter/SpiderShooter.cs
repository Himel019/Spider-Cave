using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack() {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
