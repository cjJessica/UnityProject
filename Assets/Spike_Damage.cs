using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Damage : MonoBehaviour
{
    public GameObject player;
    private int damage = 1;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            if (player != null)
            {
                Debug.Log("Spikes!!");
                other.GetComponent<Player_Health>().HealthDamage(damage);
            }
        }
    }
}
