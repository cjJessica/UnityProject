using UnityEngine;
using TMPro;

public class CoinPickUp : MonoBehaviour
{
    //declaring coin variable
    private float coin = 0;

    //Declares the score text using TextMeshPro
    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other) {
        //if the player touches an object with the tag "Coin", the coin object
        //will be destroyed and the score text will be updated by 1
        if(other.transform.tag == "Coin") {
            coin ++;
            textCoins.text = "Score: " + coin.ToString();
            Destroy(other.gameObject);
            
        }
    }
}
