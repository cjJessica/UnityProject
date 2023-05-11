using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    [Header ("Enemy Variables")]
    public Vector2 enemyPos;
    public float slimeSpeed = 4f;
    public float currentEnemyPos;
    public bool flip = true;
    
    [Header ("Player Variables")]
    public GameObject player;
    public Vector2 playerPos;
    
    [Header ("Components")]
    public Animator animator;
    Rigidbody2D enemyRB;
    


    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        
        //gets the player's position even thought this script is not attached to the player object
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Transform>();


    }


    void Update()
    {
        //////Lets the enemy flip left or right//////

        Vector3 scale = transform.localScale;
        
        //The flipping condition is controled by whether the player's position is greater or less than the enemy's
        if (player.transform.position.x > transform.position.x)
        {
            //with Abs: Absolute you can change the scale with multiply by -1 (or nothing) and using a teranary operation: of flip is true 
            //then * by -1 else * by 1.
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);  
        } else 
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }

        transform.localScale = scale;
    }


    void FixedUpdate()
    {
        ////If the player is near enemy, enemy wakes up and tracks player////

        //Makes variables for the player and enemy's positions
        playerPos = player.transform.position;
        enemyPos = transform.position;
        
        //controls the amount of distance the player has to be to wake the enemy
        if (Mathf.Abs(playerPos.x - enemyPos.x) <= 9.9 && Mathf.Abs(playerPos.y - enemyPos.y) <= 5)
        {
            //Once awakened, the animation parameter will trigger and enemy will start to walk 
            //the enemy will then follow the player at a slower speed
            enemyPos.x = Mathf.MoveTowards(enemyPos.x, playerPos.x, Time.deltaTime * slimeSpeed);
            transform.position = enemyPos;
            animator.SetBool("wasAwakened", true);


        } else
        {
            animator.SetBool("wasAwakened", false);
        }



    }



}
