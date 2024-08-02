using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // use this to load scenes

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer; // public LSPlayer reference variable called thePlayer

    private MapPoint[] allPoints; // array for all map points

    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>(); // find all map point objects in scene

        // loop through them all one by one until we find one that has the same String name thats in our PlayerPrefs in LevelManager
        // check if a key has been stored for our current level
        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            // for each MapPoint variables in allPoints array
            foreach(MapPoint point in allPoints)
            {
                // if point we're currently looking at
                if(point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position; // move player to that position
                    thePlayer.currentPoint = point; // assign player value to our current point
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // load a level
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo()); // calling the LoadLevelCo Coroutine function
    }

    // Coroutine, special function that performs time-based operations, runs on its own time outside the other normal functions, asynchronous so it runs independently from the main program flow
    public IEnumerator LoadLevelCo()
    {
        AudioManager.instance.PlaySFX(4); // level selected audio source, element 4 in unity

        yield return new WaitForSeconds(1f); // wait for one second

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad); // load the scene that the player is standing on, the value is in levelToLoad
    }
}
