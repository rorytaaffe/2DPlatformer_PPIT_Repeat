using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // creating an instance of PlayerHealthController script, meaning we can access it from any other script , static means that this cannot be changed

    public int currentHealth, maxHealth;

    // these two variables will be used so the player has a cooling off period before taking damage again, so if they run into multiple spikes they dont just die straight away
    public float invincibleTime;
    private float invincibleCount;

    private SpriteRenderer SR; // variable used to access sprite renderer component, we'll be using this to change the color of the player when he's invincible

    public GameObject deathEffect; // reference to the death effect

    // Awake is called just before the Start function
    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = PlayerHealthController
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCount > 0)
        {
            invincibleCount -= Time.deltaTime; // take away 1 from invincibleCount every 1 second depending on frame rate of game, more consistent than just -1 or --

            // when the invincible counter reaches zero while the loop above is decreasing the invincible counter value every 1 second
            if(invincibleCount <= 0)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f); // put the a value of the sprite renderer for the player back to one to signify that the invincibility period is over
            }
        }
    }

    public void DealDamage()
    {
        // if our invincibility is at or less than zero
        if(invincibleCount <= 0)
        {
        //currentHealth -= 1; // take 1 away from our current health
        currentHealth--; // take away 1 from current health

        // if the players health is below or equal to zero
        if(currentHealth <= 0)
        {
            currentHealth = 0; // set the players health to zero in case it goes below zero
            //gameObject.SetActive(false); // makes the gameObject(player) disappear

            Instantiate(deathEffect, transform.position, transform.rotation); // instantiate creates a new copy of an object, what object we're copying, what position, what rotation 

            LevelManager.instance.RespawnPlayer(); // call the RespawnPlayer function in LevelManager
        }

        // if player health is any number above zer
        else
        {
            invincibleCount = invincibleTime;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, .5f); // setting the a value in the sprite renderer component for the player as .5 when they're invincible

            PlayerController.insance.KnockBack(); // calling the knockback function in PlayerController script using instance

            AudioManager.instance.PlaySFX(9); // Element 9 is Player Hurt in Audio Manager component
        }

        UIController.instance.UpdateHealthDisplay(); // using instance to call the UpdateHealthDisplay() function in UIController script
        }
    }

    public void HealPlayer()
    {
        //currentHealth = maxHealth; // this would make our health instantly go to max, which is not what we want

        currentHealth++; // add one to our current health

        // checking if current health for some reason goes above max health
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // set current health to our set maximum health
        }

        UIController.instance.UpdateHealthDisplay(); // update our health being shown on the top right of the screen by calling th UpdateHealthDisplay in UIController script
    }

    // enter collision area
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // if the gameobject the player has collided with has the tag of Platform
        if(other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform; // set the platform to be the parent of the player, letting us stay on it while its moving
        }
    }

    // exit collision area 
    private void OnCollisionExit2D(Collision2D other)
    {
        // if the gameobject the player has exited collision with has the tag of Platform
        if (other.gameObject.CompareTag("Platform"))
        {
            //transform.parent = null; // unparent the player from the platform // this was giving me compile issues

            // Delay the parenting operation to avoid activation/deactivation issues
            Invoke("RemoveParent", 0.1f);

        }
    }

    void RemoveParent()
    {
        transform.SetParent(null); // remove object from parent, player from moving platform 
    }
}
