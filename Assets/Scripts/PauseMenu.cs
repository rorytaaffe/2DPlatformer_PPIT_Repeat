using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ability to load scenes

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; // creating an instance/variable of this script, meaning we can access it from any other script
    public String levelSelect, mainMenu; // will hold the names of the scenes to be loaded in Unity

    public GameObject pauseScreen; // reference to pause menu object
    public bool isPaused; // check if game is currently paused

    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = PauseMenu
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses the escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause(); // call the function to open/close the pause menu
        }
    }

    public void PauseUnpause()
    {
        // if the game is paused
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false); // close the pause menu
            Time.timeScale = 1; // resumes gameplay
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true); // open the pause menu
            Time.timeScale = 0f; // pauses gameplay
        }
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name); // combines CurrentLevel with the actual name of the current level into one string

        SceneManager.LoadScene(levelSelect); // load level select scene
        Time.timeScale = 1; // resumes gameplay
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu); // load main menu scene
        Time.timeScale = 1; // resumes gameplay
    }
}
