using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine; // allows us to use certain elements that are built into Unity, e.g Physics,Colliders,Transform(Position/Rotation/Size)
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]// you cant add a playercontroller to a game object unless a rigidbody exists, and if there is a playercontroller then you cant remove the rigidbody from the gameobject until the playercontroller has been removed
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController insance; // creating an instance of PlayerController script, meaning we can access it from any other script

    public float moveSpeed;
    public Rigidbody2D rb; // reference to the Rigidbidy object, public allows us to edit it in Unity
    public float jumpPower; 

    private bool isGrounded; // checks whether we're on the ground or not
    public Transform groundCheckPoint; // Transform allows us to access the Transform Component, position/rotation/scale of an object
    public LayerMask whatIsGround; // checks what layer is the ground layer
    private bool canDoubleJump; // used to check if we can double jump

    private Animator anim; // anim holds the reference to the Animator component
    private SpriteRenderer sr; // sr holds the reference to the SpriteRendere component

    public float knockBackLength, knockBackPower; // how long the knockback will last, how powerful the knockback will be
    private float knockBackCount; // counter to keep track of the length 

    public float bouncePower; // how much we want our player to bounce up in the air

    public bool stopInput;

    // Awake is called just before the Start function
    private void Awake()
    {
        insance = this; // instance = this current component / script , so the variable instance is = PlayerController
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // retrieves the Animator component attached to the same GameObject
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the game isnt paused && we havent said to stop input
        if(!PauseMenu.instance.isPaused && !stopInput)
        {
            // all the player controls will be allowed to happen as long as the knockback counter is less than zero, or that a knockback isnt happening
            if(knockBackCount <= 0)
            {
                rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y); // applying velocity, Input.GetAxisRaw("Horizontal") allows us to use the arrow keys to move , moveSpeed = the X axis, rb.velocity.y = Y axis, only updating the X in this line

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround); // going to create an imaginary circle at the player's feet that we'll use to determine whether we're on the ground

                // if we're on the ground
                if(isGrounded)
                {
                    canDoubleJump = true; // we can double jump
                }

                // check if the Jump button is pressed, we know it's Space by going to Edit , Project Settings , Input Manager , Axis , Jump
                // GetButtonDown is the first moment the button is pressed
                if(Input.GetButtonDown("Jump"))
                {
                    if(isGrounded)
                    {
                        // make the player jump when you press the Space Bar
                        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                        AudioManager.instance.PlaySFX(10); // Element 10 is Player Jump in Audio Manager component
                    }
                    else
                    {
                        if(canDoubleJump)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                            canDoubleJump = false; // canDoubleJump will always be false after we do it once, meaning we cant keep jumping infinitely
                            AudioManager.instance.PlaySFX(10); // Element 10 is Player Jump in Audio Manager component
                        }
                    }

                }

                // if you're pressing the left arrow key
                if(rb.velocity.x < 0)
                {
                    sr.flipX = true; // flip the player to the left
                }
                // if you're pressing the right arrow key
                else if (rb.velocity.x > 0)
                {
                    sr.flipX = false; // flip the player to the right
                }
            }
            // if the knockback counter is more than zero, or that a knockback is happening
            else
            {
                knockBackCount -= Time.deltaTime; // make the knockback counters value decrease

                // knockback the player depending on which way the player is facing, send them in the opposite direction away from the danger
                // if we're facing to the right, this is a shorter way of typing sr.flipX == false
                if(!sr.flipX)
                {
                    rb.velocity = new Vector2(-knockBackPower, rb.velocity.y); // updating rigidbody velocity of player, send player to the left by (-) the knockBackPower to the x value
                }
                // if we're facing left, this is a shorter way of typing sr.flipX == true 
                else if(sr.flipX)
                {
                    rb.velocity = new Vector2(knockBackPower, rb.velocity.y); // send the player to the right by (+) the knockBackPower to the x value
                }
            }
        }

        anim.SetFloat("moveSpeed", MathF.Abs(rb.velocity.x)); // Update the moveSpeed parameter in the Animator, MathF.Abs ensures the speed is always positive, as before it was registering the left arrow movement as a minus number
        anim.SetBool("isGrounded", isGrounded); // Pass the isGrounded value to the Animator
    }

    public void KnockBack()
    {
        knockBackCount = knockBackLength;
        rb.velocity = new Vector2(0f, knockBackPower); // update the player y velocity to the value we set the knockBackPower variable to in unity

        anim.SetTrigger("hurt"); // activate the hurt animation
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bouncePower); // tells the rigidbody to move us upwards in the air using the value in the bouncePower variable
        AudioManager.instance.PlaySFX(10); // Element 10 is Player Jump in Audio Manager component
    }
    
}
