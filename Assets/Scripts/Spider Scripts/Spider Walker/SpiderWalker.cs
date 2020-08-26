using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;

    private bool collision;

    [SerializeField]
    private float speed = 1f;

    private Rigidbody2D myRigidbody;
    private GameplayController gameplayController;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();
        gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    private void ChangeDirection() {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Platform"));
        
        //Debug.DrawLine(startPos.position, endPos.position, Color.green);

        Vector2 temp = transform.localScale;

        if(!collision) {
            temp.x = (-1) * temp.x;
        }

        transform.localScale = temp;
    }

    private void Move() {
        myRigidbody.velocity = new Vector2(transform.localScale.x, 0f) * speed;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            Destroy(gameObject);
            gameplayController.PlayerDied();
        }
    }
}
