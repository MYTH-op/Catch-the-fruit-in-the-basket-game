using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Basket"))
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            // trigger catch event
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            // Handle missed Fruit, like reducing lives or ending the game
            Destroy(gameObject);
        }
    }
}