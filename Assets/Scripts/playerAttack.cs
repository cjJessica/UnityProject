using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            Attack();
            /*
            print("1 pressed");
            animator.SetBool("Attack", true);
            animator.SetInteger("AttackNum", 1);
            */
            
            
        } /*else
        {
            animator.SetBool("Attack", false);
            animator.SetInteger("AttackNum", 0);
        }*/
    }

    void Attack()
    {
        int randomNumber = Random.Range(0, 4);
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackNum", (randomNumber));
    }
}
