using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left; // references to other Map Points
    public bool isLevel; // used to identify if a map point is a level
    public String levelToLoad; // name of the level we want to load,

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
