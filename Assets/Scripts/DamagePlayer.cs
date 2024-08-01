using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
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
        // if the collider that interacts with our spikes is the player collider
        if(other.tag == "Player")
        {
            //Debug.Log("Hit"); // log "Hit" to the console

            //FindObjectOfType<PlayerHealthController>().DealDamage(); // FindObjectOfType will search every object in the scene , finds PlayerHealthController , calls the DealDamage function

            PlayerHealthController.instance.DealDamage(); // search unity for the static instance of the PlayerHealthController that is stored in memory , on this instance call the DealDamage function       

        }

    }

}
