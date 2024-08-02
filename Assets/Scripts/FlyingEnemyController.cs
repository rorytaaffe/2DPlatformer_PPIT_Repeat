using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points; // transform array called points, will store the points in here
    public float moveSpeed; // how fast the enemy will fly
    private int currentPoint; // keep track of what point they're going towards
    public SpriteRenderer sr; // reference to sprite renderer


    // Start is called before the first frame update
    void Start()
    {
        // loop through the length of the array
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null; // make sure the points are no longer parented to the flying enemy object
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed); // where they are, where they're going, speed

        // if the distance to the next point is only .05f away or very close
        if(Vector3.Distance(transform.position, points[currentPoint].position) <.05f)
        {
            currentPoint++; // go to next element in array

            // if the number after the ++ is greater than or equal to the largest number in the array
            if(currentPoint >= points.Length)
            {
                currentPoint = 0; // set it to the first point again
            }
        }

        // if the flying enemies x position is less than the point its moving towards
        if(transform.position.x < points[currentPoint].position.x)
        {
           sr.flipX = true; // flip the sprite to the other direction
        }
        // if the flying enemies x position is more than the point its moving towards
        else if(transform.position.x > points[currentPoint].position.x)
        {
            sr.flipX = false; // dont flip
        }
    }
}
