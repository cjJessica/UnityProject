using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    //Variables
    Rigidbody2D rb;
    public Animator animator;

    public GameObject attackPoint;
    //public float attackRange = 0.5f;
    public LayerMask enemies;
    public float radius;
    //public int attackDamage = 10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //When user presses q on the keyboard the attack method/function is called
        if (Input.GetKey("q"))
        {
            Attack();
        } 
    }


    //when attack method is ran, a random attack animation, out of the four available, is played
    void Attack()
    {
        //animation parameter, "attack" will trigger causing the animation to run
        //animation parameter, "AttackNum" is given a random number of 1-4, which chooses which of the four action animations to play
        int randomNumber = Random.Range(0, 4);
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackNum", (randomNumber));

    }
        /*
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach(Collider2D enemyGameObject in enemy)
        {
            enemyGameObject.GetComponent<slime_AttackAndHealth>().TakeDamage(attackDamage);
        }*/

    

/*
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }*/
}
