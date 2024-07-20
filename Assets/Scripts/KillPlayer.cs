using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function that waits for a certain object to hit or trigger it
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // if the player object hits or triggers the box collider KillPlane
        if(other.tag == "Player")
        {
            LevelManager.instance.RespawnPlayer(); // respawn the player at the designated respawn point 
        }
    }
}
