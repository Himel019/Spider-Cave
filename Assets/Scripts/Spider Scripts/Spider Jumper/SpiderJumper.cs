using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 300f;
    [SerializeField]
    private float minJumpForce = 17000;
    [SerializeField]
    private float maxJumpForce = 19000;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private GameplayController gameplayController;

    void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack() {
        yield return new WaitForSeconds(Random.Range(2, 7));

        jumpForce = Random.Range(minJumpForce, maxJumpForce);

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
            gameplayController.PlayerDied();
        }
    }
}
