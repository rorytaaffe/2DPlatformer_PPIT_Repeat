using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch; // the object we want to switch
    private SpriteRenderer sr; // reference to sprite renderer 
    public Sprite downSprite; // the sprite we want to switch it to
    private bool hasSwitched; // have we used the switch yet or not
    public bool deactivateOnSwitch; // used for deactivating objects

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // retrieves the SpriteRenderer component attached to the same GameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // trigger detection  function
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // if the player hits the switch && if it hasnt been hit yet before
        if(other.tag == "Player" && !hasSwitched)
        {
            // if the object needs to be deactivated
            if(deactivateOnSwitch)
            {
                objectToSwitch.SetActive(false); // deactivate the object
            }
            else 
            {
                objectToSwitch.SetActive(true); // activate the object
            }

            sr.sprite = downSprite; // set the sprite to be the down sprite
            hasSwitched = true; // set it to be true
        }
    }
}
