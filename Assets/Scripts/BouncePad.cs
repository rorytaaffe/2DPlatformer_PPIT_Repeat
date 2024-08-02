using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private Animator anim; // animator reference
    public float bounceForce = 20f; // force to send player up in air

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // retrieves the Animator component attached to the same GameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerController.insance.rb.velocity = new Vector2(PlayerController.insance.rb.velocity.x, bounceForce); // tell the PlayerController to send the player up in the air
            anim.SetTrigger("Bounce"); // set the animation
        }
    }
}
