using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_AttackAndHealth : MonoBehaviour
{
    //public GameObject slime;
    public GameObject player;

    public Vector2 playerPos;
    public Vector2 slimePos;

    public int MaxHealth = 100;
    int currentHealth;

    public bool attack;
    public float attackRate = 10f;
    float nextAttackTime = 0f;

    private int slimeDamage = 1;

    public Animator animator;
    
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        //slime = GameObject.Find("Slime1");
        player.GetComponent<Transform>();
        attack = false;
    }

    void Update()
    {
        playerPos = player.transform.position;
        slimePos = transform.position;
        Debug.Log(animator.GetBool("Attacking"));

        if (Time.time >= nextAttackTime)
        {
            if (Mathf.Abs(playerPos.x - slimePos.x) <= 4.4)
            {
                animator.SetBool("Attacking", true);
                //attack = true;
                nextAttackTime = Time.time + 1f / attackRate;
            } else
            {
                animator.SetBool("Attacking", false);
            }
        }  
  

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            //Debug.Log(attack);
                
            if (animator.GetBool("Attacking"))
            {
                Debug.Log("Slime attack!");
                player.GetComponent<Player_Health>().HealthDamage(slimeDamage);
            }

        }
    }
    



    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        slimePos = transform.position;

        currentHealth -= damage;

        GetComponent<enemyFollow>().enabled = false;

        if (player.transform.position.x > transform.position.x)
        {
            slimePos.x -= 2;
            slimePos.y += 1;
        } else
        {
            slimePos.x += 2;
            slimePos.y += 1;
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
