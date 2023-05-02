using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    Rigidbody2D enemyRB;

    //public GameObject enemy;
    public Vector2 enemyPos;
    public float slimeSpeed = 5f;
    public float currentEnemyPos;
    public bool isFacingRight = true;
    
    public GameObject player;
    public Vector2 playerPos;
    
    public Animator animator;
    
    //bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        

        player = GameObject.FindWithTag("Player");
        player.GetComponent<Transform>();

        currentEnemyPos = transform.position.x;
    }

    void Update()
    {
        //currentEnemyPos = transform.position.x;

        if (transform.position.x > currentEnemyPos && isFacingRight)
        {
            //print("flip now");
            currentEnemyPos = transform.position.x;
            Flip();   
        }

        if (transform.position.x < currentEnemyPos && !isFacingRight)
        {
            currentEnemyPos = transform.position.x;
            Flip();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;
        enemyPos = transform.position;
        
        if (playerPos.x + 9.9f >= enemyPos.x)
        {
            //Vector3 pos = transform.position;
            enemyPos.x = Mathf.MoveTowards(enemyPos.x, playerPos.x, Time.deltaTime * slimeSpeed);
            transform.position = enemyPos;
            animator.SetTrigger("wasAwakened");

/*
            if (transform.position.x < currentEnemyPos)
            {
                transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
                currentEnemyPos = transform.position.x;
            }*/
        }
        //transform.position = new Vector3(trackingTarget.position.x + )
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //print(currentEnemyPos);
        
    }

}
