using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public GameObject hitBox;
    //public GameObject slime;
    public int attackDamage = 10;

    void Start() 
    {
        //hitBox = GameObject.Find("Attack1");
        //slime = GameObject.Find("Slime1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            if (hitBox != null)
            {
                //Debug.Log("hit enemy");
                other.GetComponent<slime_AttackAndHealth>().TakeDamage(attackDamage);
            }
            
        }
    }

}
