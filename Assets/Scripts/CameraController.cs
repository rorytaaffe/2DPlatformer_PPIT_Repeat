using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance; // creating an instance/variable of this script, meaning we can access it from any other script

    public Transform target;

    public Transform farBackground, middleBackground; // will be used to make the background move with us as we move

    public float minHeight, maxHeight; // height of the camera as we jump/fall

    public bool stopFollow; 

    //private float lastXPos; 
    private Vector2 lastPos; // Vector2 only affects the X & Y values

    private void Awake() 
    {
        instance = this; // instance = this current component / script , so the variable instance is = CameraController
    }

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x; // this is where our camera starts at, so it's at zero
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if we want the camera to follow the player
        if(!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z); // makes sure if clampedY(transform.position.y) goes above or below the min/max height we set in Unity, it will reset the current height to be within those parameters       

            // how much we're moving from one frame to the next, every time we do an update how far are we moving as we go
            //float amountToMoveX = transform.position.x - lastXPos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y); 

            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f); // 
            middleBackground.position  += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f; // move 1/2 the distance as the far background is moving by multiplying x & y by .5 , the z value is already set to zero

            //lastXPos = transform.position.x;
            lastPos = transform.position;
        }
    }
}
