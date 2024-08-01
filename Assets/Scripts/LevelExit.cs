using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // trigger function
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // if the player enters the trigger area
        if(other.tag == "Player")
        {
            LevelManager.instance.EndLevel(); // // calls the EndLevel function which ends the level
        }
    }
}
