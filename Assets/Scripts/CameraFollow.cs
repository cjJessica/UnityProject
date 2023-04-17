using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    /*
    public GameObject followTarget;
    public float moveSpeed;

    private Vector3 targetPos;
    */

    //public float interpVelocity;
    //public float minDistance;
    //public float followDistance;
    //public GameObject target;
    public Transform trackingTarget;
    public float xOffset;
    public float yOffset;
    //public Vector3 offset;
    //public float cameraSpeed = 0f;
    //Vector3 targetPos;
    //Use this for initialization

    void Start () {
        //targetPos = transform.position;
    }

    void FixedUpdate () {

        transform.position = new Vector3(trackingTarget.position.x + xOffset, trackingTarget.position.y + yOffset, transform.position.z);
        
        /*
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
        */
    }
/*
    void Update() {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    */
}
