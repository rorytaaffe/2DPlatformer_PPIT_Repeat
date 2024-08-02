using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint; // what point are we currently at

    public float moveSpeed = 10f; // how fast the player will move
    private bool levelLoading; // used to check if we are loading a level

    public LSManager theManager; // public LSManager reference variable called theManager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime); // move the player

        // check to see if our player object is .1f or really close to the next desired map point && we are not loading a level
        if(Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {
            // if the player has pressed right
            if(Input.GetAxisRaw("Horizontal") > .5f)
            {
                // check if theres something in the right element in the current map point 
                if(currentPoint.right != null)
                {
                    //currentPoint = currentPoint.right; // our current piont is = whatever is on the right of our current point
                    SetNextPoint(currentPoint.right); // set current map point to the next point 
                }
            }

            // if the player has pressed left
            if(Input.GetAxisRaw("Horizontal") < -.5f)
            {
                // check if theres something in the left element in the current map point 
                if(currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left); // set current map point to the next point 
                }
            }

            // if the player has pressed up
            if(Input.GetAxisRaw("Vertical") > .5f)
            {
                // check if theres something up from element in the current map point 
                if(currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up); // set current map point to the next point 
                }
            }

            // if the player has pressed down
            if(Input.GetAxisRaw("Vertical") < -.5f)
            {
                // check if theres something down from element in the current map point 
                if(currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down); // set current map point to the next point 
                }
            }

            // if our current point is at a level && levelToLoad isnt empty
            if(currentPoint.isLevel && currentPoint.levelToLoad != "")
            {
                // if the player presses the jump button
                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true; // loading a level = true

                    theManager.LoadLevel(); // calls LoadLevel() in LSManager
                }
            }
        }
    }

    // call this to set next map point, takes MapPoint as a value
    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint; // set current map point to the next point

        AudioManager.instance.PlaySFX(5); // map movement audio source, element 5 in unity
    }
}
