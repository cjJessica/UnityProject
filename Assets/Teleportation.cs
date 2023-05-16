using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportText;
    
    public Vector2 playerPos;
    public Vector2 ladderPos;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Transform>();
        teleportText.SetActive(false);

    }

    // Update is called once per frame
    //(95, -5)
    void Update()
    {
        playerPos = player.transform.position;
        ladderPos = transform.position;

        if (Mathf.Abs(playerPos.x - ladderPos.x) <= 1.1)
        {
            //PLAYER.Set
            teleportText.SetActive(true);
            
            if(Input.GetKey("t"))
            {
                playerPos.x = 95;
                playerPos.y = -5f;
                player.transform.position = playerPos;
            }

        } else
        {
            teleportText.SetActive(false);
        }
    }
}
