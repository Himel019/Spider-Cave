using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    private float force = 500f;

    private Animator myAnimator;

    void Awake() {
        myAnimator = GetComponent<Animator> ();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.gameObject.GetComponent<Player>().BouncePlayerWithBouncer(force);
            myAnimator.SetTrigger("Bounce");
        }
    }
}
