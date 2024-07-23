using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isEmerald, isHealth; // use these variables to identify what kind of pickup it is

    private bool isCollected; // used to check if the pickup has already been collected

    public GameObject pickupEffect; // reference to the pickup effect object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // if the player object hits or triggers the circle collider Emerald && the emerald pickup hasnt already been collected
        if(other.tag == "Player" && !isCollected)
        {
            // if its an emerald pickup
            if(isEmerald)
            {
                LevelManager.instance.emeraldsCollected++; // add one onto the emeraldCollected variable in LevelManager 

                isCollected = true; // setting variable to true so unity knows its already been picked up
                Destroy(gameObject); // remove the emerald game object from the scene

                Instantiate(pickupEffect, transform.position, transform.rotation); // instantiate creates a new copy of an object, what object we're copying, what position, what rotation

                UIController.instance.UpdateEmeraldCount(); // call the UpdateEmeraldCount function in UIController using an instance

                AudioManager.instance.PlaySFX(6); // Element 6 is Pickup Emerald in Audio Manager component
            }

            // if its a health pickup
            if(isHealth)
            {
                // if the player isnt at full health
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer(); // call the healPlayer function in PlayerHealthController

                    isCollected = true; // setting variable to true so unity knows its already been picked up
                    Destroy(gameObject); // remove the emerald game object from the scene

                    Instantiate(pickupEffect, transform.position, transform.rotation); // instantiate means create a new copy of an object, what object we're copying, what position, what rotation

                    AudioManager.instance.PlaySFX(7); // Element 7 is Pickup Health in Audio Manager component
                }
            }
        }
    }

}
