using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Block : MonoBehaviour
{
    public Animator animator;
    //public GameObject slime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("b"))
        {
            Block();

        } else
        {
            animator.SetBool("isBlocking", false);
            GetComponent<playerAttack>().enabled = true;
            GetComponent<Player_Health>().enabled = true;

        }
    }


    void Block()
    {
        //GetComponent<Player_Health>().enabled = false;
        //Debug.Log("blocking");
        animator.SetBool("isBlocking", true);
        GetComponent<playerAttack>().enabled = false;
        


    }
}
