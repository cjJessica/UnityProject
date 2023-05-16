using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    int currentHealth;
    public int MaxHealth = 3;
    public Vector2 playerPos;
    public Animator animator;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    public void HealthDamage(int damage)
    {
        if (!animator.GetBool("isBlocking"))
        {
            playerPos = transform.position;

            int randomNumber = Random.Range(0, 2);
            animator.SetTrigger("hit");
            animator.SetInteger("hitNum", (randomNumber));

            currentHealth -= damage;

            playerPos.x = 22.4f;
            playerPos.y = -6.74f;
            transform.position = playerPos;

            if (currentHealth <= 0)
            {
                Die();
            }
        }


    }

    void Die()
    {
        Debug.Log("Player is Dead");
        animator.SetTrigger("Died");
    }
}
