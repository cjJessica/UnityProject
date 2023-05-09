using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_AttackAndHealth : MonoBehaviour
{
    //public GameObject slime;
    public GameObject player;
    public int MaxHealth = 100;
    int currentHealth;
    public Animator animator;
    public Vector2 slimePos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        //slime = GameObject.Find("Slime1");
        player.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        slimePos = transform.position;

        currentHealth -= damage;

        GetComponent<enemyFollow>().enabled = false;

        if (player.transform.position.x > transform.position.x)
        {
            slimePos.x -= 1;
        } else
        {
            slimePos.x += 1;
        }

        transform.position = slimePos;
        GetComponent<enemyFollow>().enabled = true;

        if(currentHealth <= 0)
        {
            Die();
        }
    }



    void Die()
    {
        Debug.Log("dead");
        animator.SetTrigger("died");
        if (this.gameObject != null)
        {
            GetComponent<enemyFollow>().enabled = false;

            Destroy(this.gameObject, 1.9f);
        }
    }
}
