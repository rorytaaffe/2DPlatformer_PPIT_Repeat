using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // creating an instance/variable of this script, meaning we can access it from any other script

    public float waitToRespawn;

    // Awake is called just before the Start function
    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = LevelManager
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo()); // calling the RespawnCo Coroutine function
    }

    // Coroutine, special function that performs time-based operations, runs on its own time outside the other normal functions , asynchronous so it runs independently from the main program flow
    private IEnumerator RespawnCo()
    {
        PlayerController.insance.gameObject.SetActive(false); // deactivate the player game object

        yield return new WaitForSeconds(waitToRespawn); // yield return is waiting for a value to be true, the value its waiting for is WaitForSeconds which is waiting for waitToRespawn value to end
                                                        // when this line is done waiting, it will move onto the next line below

        PlayerController.insance.gameObject.SetActive(true); // reactivate player game object

        PlayerController.insance.transform.position = CheckpointController.instance.spawnPoint; // resetting the players position to the spawnPoint variables value in CheckpointController

        // tell the PlayerHealthController to refill the players health
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; // set the current health of player to max health using instances
        // update UI to show the health has been refilled
        UIController.instance.UpdateHealthDisplay(); // calls the UpdateHealthDisplay which fills up the 3 heart sprites at the top of the screen
    }
}
