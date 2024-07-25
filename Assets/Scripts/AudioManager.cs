using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // creating an instance/variable of this script, meaning we can access it from any other script

    public AudioSource[] soundEffects; // reference to Audio Source component, array of sound effects

    public AudioSource backGroundMusic, levelEndMusic; // background music, end of level music

    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = AudioManager
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function will be called when we want to play a sound effect 
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop(); // in case the sound effect is already playing, stop it before playing it again, e.g if the player is picking up multiple Emeralds soon after each other

        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f); // Randomizes the pitch of the sound effect every time so it sounds slightly different every time, within the range values .9f to 1.1f

        soundEffects[soundToPlay].Play(); // passing an int value into the soundEffects array, .Play will play the sound
    }
}
