using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{   
    Rigidbody2D rb;  //use variable rb to reference rigidbody
    
    public GameObject character;
    public float movementSpeed = .01f;  //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis

    public Animator animator;

    bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //rb = rigidbody on player
        

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");  //d key changes to 1, a key changes value to -1
        animator.SetFloat("speed", Mathf.Abs(movement.x)); //Conects player animation with the player's movement

        //controls which way the player is facing
        if (isFacingRight && movement.x < 0 || !isFacingRight && movement.x > 0)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        
        //Left and Right Arrows controls the player's movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(movementSpeed, 0));   
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-movementSpeed, 0));
        }
    }

    //Flips the character animation by adding or taking away a negative in the player's transform scaleX position
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

}


