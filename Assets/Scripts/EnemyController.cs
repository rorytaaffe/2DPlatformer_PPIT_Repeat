using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed; // movement speed of enemy

    public Transform leftPoint, rightPoint; // the two points we want the enemy to move to and from

    private bool movingRight; // needed to know whether the enemy is moving to the left or right

    private Rigidbody2D rb; // reference variable to the Rigidbody2D component
    public SpriteRenderer sr; // reference variable to the SpriteRenderer component
    private Animator anim; // reference to the animator

    public float moveTime, waitTime; // how long we want them to move/wait
    private float moveCount, waitCount; // use these values to count down from

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // setting the value of our variable rb to the Rigidbody2D component 
        anim = GetComponent<Animator>(); // setting the value of our variable anim to the Animator component 

        leftPoint.parent = null; // removes these as children of the enemy when the game starts
        rightPoint.parent = null; 

        movingRight = true; // initial direction

        moveCount = moveTime; // telling him how long to move for
    }

    // Update is called once per frame
    void Update()
    {
        // if the count has a value more than 0
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime; // take away 1 from moveCount every 1 second depending on frame rate of game, more consistent than just -1 or --

            // if the enemy is moving right
            if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // tell the Rigidbody2D how fast we want to move

                sr.flipX = true; // enemy is facing left by default, so flip right if moving right

                // check if we are at the point we want to get to
                // if we've gone too far to the right past where the RightPoint is
                if (transform.position.x >= rightPoint.position.x)
                {
                    movingRight = false; // start moving left
                }
            }
            else // if the enemy is moving left
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // tell the Rigidbody2D how fast we want to move

                sr.flipX = false; // dont flip x if already facing left

                // if we've gone too far to the left past the LeftPoint
                if (transform.position.x <= leftPoint.position.x)
                {
                    movingRight = true; // start moving right
                }
            }

            // if moveCount has counted down to below zero
            if(moveCount <= 0)
            {
                //waitCount = waitTime; // tell waitCount to start working
                waitCount = Random.Range(waitTime * .75f, waitTime * 2f); // chooses a random time between 3/4 of our wait time & double our wait time
            }

            anim.SetBool("isMoving", true); // telling it when we want the enemy to animate, when its moving we want it to be animating
        }

        // if the waitCount has a value
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime; // take away 1 from waitCount every 1 second depending on frame rate of game, more consistent than just -1 or -- 
            rb.velocity = new Vector2(0f, rb.velocity.y); // tell the enemy to stand still by setting the x velocity to 0

            // check if the wait time has ended
            if(waitCount <= 0)
            {
                //moveCount = moveTime; // telling him how long to move for
                moveCount = Random.Range(moveTime * .75f, moveTime * 2f); // chooses a random time between 3/4 of our move time & double our move time
            }
            anim.SetBool("isMoving", false); // when its not moving we dont want it to animate
        }
    }
}
