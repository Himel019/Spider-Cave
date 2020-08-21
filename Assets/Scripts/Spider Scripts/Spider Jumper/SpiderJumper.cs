using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 300f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack() {
        yield return new WaitForSeconds(Random.Range(2, 7));

        jumpForce = Random.Range(17000, 19000);

        myRigidbody.AddForce(new Vector2(0, jumpForce));
        myAnimator.SetBool("Attack", true);

        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground") {
            myAnimator.SetBool("Attack", false);
        }

        if(other.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
