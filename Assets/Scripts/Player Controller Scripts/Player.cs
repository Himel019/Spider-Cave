using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float initialSpeed;

    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float maxSpeed = 12f;
    [SerializeField]
    private float jumpForce = 700f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 horizontalMove = new Vector2(horizontal * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = horizontalMove;

        if(speed < maxSpeed && horizontal != 0 && isGrounded) {
            speed += 0.01f;
            myAnimator.SetBool("Run", true);
        } else {
            speed = initialSpeed;
            myAnimator.SetBool("Run", false);
        }

        if(horizontal < 0) {
            mySpriteRenderer.flipX = true;
        } else if(horizontal > 0) {
            mySpriteRenderer.flipX = false;
        } 
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(isGrounded){
                isGrounded = false;
                myRigidbody.AddForce(new Vector2(myRigidbody.velocity.x, jumpForce));
                myAnimator.SetBool("Jump", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground") {
            myAnimator.SetBool("Jump", false);
            isGrounded = true;
        }
    }
}
