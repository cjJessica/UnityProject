using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    int currentHealth;
    public int MaxHealth = 3;
    public Vector2 playerPos;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    public void HealthDamage(int damage)
    {
        playerPos = transform.position;

        currentHealth -= damage;

        playerPos.x = 24.4f;
        playerPos.y = -6.74f;
        transform.position = playerPos;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Player is Dead");
    }
}
