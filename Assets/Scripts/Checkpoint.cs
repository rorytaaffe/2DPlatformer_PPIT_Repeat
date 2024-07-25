using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer sr;
    public Sprite cpOn, cpOff;

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
            // before we turn on the checkpoint we just triggered, reset all the other ones and turn them off
            CheckpointController.instance.DeactivateCheckpoints();

            sr.sprite = cpOn; // activate the cpOn sprite

            CheckpointController.instance.SetSpawnPoint(transform.position); // sets the current checkpoint as the new spawnpoint by passing transform.position as the value in the () brackets
        }
    }

    public void ResetCheckpoint()
    {
        sr.sprite = cpOff; // activate the cpOff sprite
    }
}
