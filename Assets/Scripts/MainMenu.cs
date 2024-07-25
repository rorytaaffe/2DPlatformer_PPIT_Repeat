using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ability to load scenes

public class MainMenu : MonoBehaviour
{
    public String startScene; // used to specify which scene we want to load in Unity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene); // startScene holds a string value in unity that we manually entered
    }

    public void QuitGame()
    {
        Application.Quit(); // this wont close the game in Unity, only if we deploy it to an app store etc
        Debug.Log("Quitting Game"); // console message
    }
}
