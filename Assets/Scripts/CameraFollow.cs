using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //Variables
    public Transform trackingTarget;  //the tracking target will be the player
    public float xOffset;             
    public float yOffset;


    void FixedUpdate () {
        //the camera's x, y, and z positions will become the player's. However the xOffset and yOffset will add to the camera's
        //x and y positions.
        transform.position = new Vector3(trackingTarget.position.x + xOffset, trackingTarget.position.y + yOffset, transform.position.z);

    }

}
