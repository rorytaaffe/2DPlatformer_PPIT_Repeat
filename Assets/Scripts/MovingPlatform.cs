using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points; // transform array called points, will store the points in here
    public float moveSpeed; // how fast the platform will move
    public int currentPoint; // keep track of what point we're going towards

    public Transform platform; // platform itself

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed); // where we are, where we're going, speed

        // if the distance to the next point is only .05f away or very close
        if(Vector3.Distance(platform.position, points[currentPoint].position) <.05f)
        {
            currentPoint++; // go to next element in array

            // if the number after the ++ is greater than or equal to the largest number in the array
            if(currentPoint >= points.Length)
            {
                currentPoint = 0; // set it to the first point again
            }
        }
    }
}
