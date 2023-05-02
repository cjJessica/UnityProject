using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    Rigidbody2D rbSlime;

    public GameObject SlimeCharacter;
    public float slimeSpeed = .01f;
    public Vector2 movement;

    bool slimeFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rbSlime = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = 1f;
        transform.Translate(new Vector2(slimeSpeed, 0));

        if (!slimeFacingRight) 
        {
            transform.Translate(new Vector2(-slimeSpeed, 0));
        }
    }

    void OnColliderEnter2D(Collider2D col)
    {
        Debug.Log("nON -Trigger");
    }
/*
    void OnColliderEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
            print("collided");
            FlipSlime();
        }
    }*/

    void FlipSlime()
    {
        slimeFacingRight = !slimeFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    
}
