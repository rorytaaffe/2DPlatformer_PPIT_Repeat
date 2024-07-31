using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect; // will instantiate after enemy death

    public GameObject collectible; // item we want the enemy to drop
    //[Range(0, 100)]public float chanceToDrop; // float within the range of 0 and 100 , used to randomize the drop rate 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // used to detect when one object enters a trigger area
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // find if we jumped on an enemy
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy"); // console message to make sure we're hitting the enemy

            // other.gameObject.SetActive(false); // this just deletes the sprite, its a child so the enemy is still technically in the game you can see it in Scene view
            other.transform.parent.gameObject.SetActive(false); // this deletes the parent GameOject too 

            Instantiate(deathEffect, other.transform.position, other.transform.rotation); // instantiate creates a new copy of an object, what object we're copying, what position, what rotation

            PlayerController.insance.Bounce(); // call the Bounce function in PlayerController using instanc

            Instantiate(collectible, other.transform.position, other.transform.rotation); // drop the collectible

            // used to randomize the drop rate
            /*
            float dropSelect = Random.Range(0, 100f); // random number between 0 and 100

            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation); // drop the collectible
            }
            */

            AudioManager.instance.PlaySFX(3); // the number passed is the number in the inspector window, so Element 3 is Enemy Explode
        }

    }
}
