using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        // Attempt to add a Mesh Renderer if missing
        TryAddRenderer();
    }

    void Update()
    {
        // Move the basket left and right based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Ensure the basket stays within the screen boundaries
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Get the Renderer component
        Renderer basketRenderer = GetComponent<Renderer>();

        // Check if the Renderer component exists
        if (basketRenderer != null)
        {
            float basketHalfWidth = basketRenderer.bounds.size.x / 2f;

            // Clamp the X position
            float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidth + basketHalfWidth, screenHalfWidth - basketHalfWidth);

            // Update the basket's position
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
        else
        {
            // Log an error message if the Renderer component is missing
            Debug.LogError("Renderer component is missing on the BasketController GameObject.");
        }
    }

    void TryAddRenderer()
    {
        // Attempt to add a Mesh Renderer if missing
        Renderer basketRenderer = GetComponent<Renderer>();

        if (basketRenderer == null)
        {
            // Attempt to add a Mesh Renderer
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                Debug.Log("Mesh Renderer added to the BasketController GameObject.");
            }
            else
            {
                Debug.LogError("Failed to add Mesh Renderer to the BasketController GameObject.");
            }
        }
    }
}
