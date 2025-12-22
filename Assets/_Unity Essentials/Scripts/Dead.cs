using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{

    public GameObject onCollectEffect;
    public AudioClip touchedCat;
    public GameObject RestartButton; // Assign your restart button here

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the other object has a PlayerController2D component
        if (other.gameObject.CompareTag("Cat"))
        {
            // Play the collect sound effect
            if (touchedCat != null)
            {
                AudioSource.PlayClipAtPoint(touchedCat, transform.position);
            }

            // Destroy the collectible
            Destroy(gameObject);
            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            RestartButton.SetActive(true);
        }
    }
    
}


