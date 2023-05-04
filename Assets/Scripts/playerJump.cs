using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class playerJump : MonoBehaviour
{

    [Header ("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator myAnimator;



    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }


    private void Update()
    {
        //what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);
        
        if (grounded) 
        {
            jumpTimeCounter = jumpTime;
            myAnimator.ResetTrigger("Jump");
            myAnimator.SetBool("Falling", false);
        }


        //if we press jump button 
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //jump!!!
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;

            //tells the animator to jump animation
            myAnimator.SetTrigger("Jump");
        }

        //if we hold the jump button
        if(Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {

            //jump!
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("Jump");
        }

        //if we release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.SetBool("Falling", true);
            myAnimator.ResetTrigger("Jump");
        }

        if (rb.velocity.y < 0) 
        {
            myAnimator.SetBool("Falling", true);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }

    //changes the animation layers from air to ground and vice versa
    private void HandleLayers()
    {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

}
