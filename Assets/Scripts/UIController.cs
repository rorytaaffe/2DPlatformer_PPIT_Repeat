using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // using the UI elements of the Unity Engine


public class UIController : MonoBehaviour
{
    public static UIController instance; // creating an instance of UIController script, meaning we can access it from any other script

    public UnityEngine.UI.Image heart1, heart2, heart3; // 3 heart images on top left of screen

    public Sprite heartFull, heartEmpty, heartHalf; // sprites for full heart and empty heart

    // Awake is called just before the Start function
    private void Awake() 
    {
        instance = this; // assigning the instance variable to this script/component
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            // if the current health is full
            case 6:
                heart1.sprite = heartFull; // all hearts are full
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break; // end of case 6

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf; // heart 3 is half because we took 1 damage

                break; // end of case 5

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty; // heart 3 is empty because we took 2 damage

                break; // end of case 4

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf; // heart 2 is half because we took 3 damage
                heart3.sprite = heartEmpty; // heart 3 is empty because we took 2 damage

                break; // end of case 3

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty; // heart 2 is empty because we took 4 damage
                heart3.sprite = heartEmpty; // heart 3 is empty because we took 2 damage

                break; // end of case 2

            case 1:
                heart1.sprite = heartHalf; // heart 1 is empty because we took 5 damage
                heart2.sprite = heartEmpty; // heart 2 is empty because we took 4 damage
                heart3.sprite = heartEmpty; // heart 3 is empty because we took 2 damage

                break; // end of case 1

            case 0:
                heart1.sprite = heartEmpty; // heart 1 is empty because we took 6 damage
                heart2.sprite = heartEmpty; // heart 2 is empty because we took 4 damage
                heart3.sprite = heartEmpty; // heart 3 is empty because we took 2 damage

                break; // end of case 0

            // in case the player health goes below zero or above 3
            default:
                heart1.sprite = heartEmpty; 
                heart2.sprite = heartEmpty; 
                heart3.sprite = heartEmpty; 

                break; // end of default
        }
    }
}
