using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance; // creating an instance/variable of this script, meaning we can access it from any other script

    private Checkpoint[] checkpoints; // Checkpoint(script) array called checkpoints

    public Vector3 spawnPoint; // where the player will spawn
    

    // Awake is called just before the Start function
    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = CheckpointController 
    }

    // Start is called before the first frame update
    void Start()
    {
        // find all the checkpoints that exist in the scene
        checkpoints = FindObjectsOfType<Checkpoint>(); // FindObjectOfType will search every object in the scene , finds Checkpoint  

        // set the spawnPoint of the player to be where the player is at the start of the level
        spawnPoint = PlayerController.insance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // deactivate all checkpoints apart from the one that we just activated
    public void DeactivateCheckpoints()
    {
        // checking if i is less than the length of the checkpoints array
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint(); // checkpoints at position i in the array , run the function ResetCheckpoint
        }
    }

    // passing a vector variable as a value in this function, meaning we can use it in this function 
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
