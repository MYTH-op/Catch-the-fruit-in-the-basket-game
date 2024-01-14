using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int score = 0;

    void Update()
    {
        // Move the basket left and right based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Ensure the basket stays within the screen boundaries
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float basketHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;

        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidth + basketHalfWidth, screenHalfWidth - basketHalfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has a tag "FallingObject"
        if (other.CompareTag("FallingObject"))
        {
            // Destroy the falling object
            Destroy(other.gameObject);

            // Increase the score
            score++;

            // You can add additional scoring logic or UI updates here if needed
            Debug.Log("Score: " + score);
        }
    }
}

