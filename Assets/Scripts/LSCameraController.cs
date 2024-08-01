using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    public Vector2 minPos, maxPos; // min and max position

    public Transform target; // what we want the camera to be moving towards

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x); // makes sure if Clamp(target.position.x) goes above or below the minPos/maxPos height we set in Unity, it will reset the current height to be within those parameters
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z); // where we want the camera to move, doesnt change z value
    }
}
