using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_AttackAndHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("dead");
    }
}
