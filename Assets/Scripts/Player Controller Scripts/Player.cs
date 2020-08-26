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
    private bool moveLeft;
    private bool moveRight;

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
        PlayerMovementJoystick();
    }

    public void SetMoveLeft(bool moveLeft) {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving() {
        this.moveLeft = false;
        this.moveRight = false;
    }

    private void PlayerMovementJoystick() {
        if(isGrounded){
            if(moveRight) {
                Vector2 horizontalMove = new Vector2((1f) * speed, myRigidbody.velocity.y);
                myRigidbody.velocity = horizontalMove;
                mySpriteRenderer.flipX = false;
                myAnimator.SetBool("Run", true);

                if(speed < maxSpeed) {
                speed += 0.01f;
                } else {
                    speed = maxSpeed;
                }
            } else if(moveLeft) {
                Vector2 horizontalMove = new Vector2((-1f) * speed, myRigidbody.velocity.y);
                myRigidbody.velocity = horizontalMove;
                mySpriteRenderer.flipX = true;
                myAnimator.SetBool("Run", true);

                if(speed < maxSpeed) {
                speed += 0.01f;
                } else {
                    speed = maxSpeed;
                }
            }
        } else {
            myAnimator.SetBool("Run", false);
        }
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

    public void Jump() {
        if(isGrounded){
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(myRigidbody.velocity.x, jumpForce));
            myAnimator.SetBool("Jump", true);
        }
    }

    public void BouncePlayerWithBouncer(float force) {
        if(isGrounded) {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(myRigidbody.velocity.x, force));
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Platforms") {
            myAnimator.SetBool("Jump", false);
            isGrounded = true;
        }
    }
}
