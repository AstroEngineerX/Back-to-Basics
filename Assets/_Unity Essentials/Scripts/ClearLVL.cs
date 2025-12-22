using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLVL : MonoBehaviour
{

    public GameObject onCollectEffect;
    public AudioClip clearObstacle;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the other object has a PlayerController2D component
        if (other.gameObject.CompareTag("Dog"))
        {
            // Play the collect sound effect
            if (clearObstacle != null)
            {
                AudioSource.PlayClipAtPoint(clearObstacle, transform.position);
            }

            // Destroy the collectible
            Destroy(gameObject);
            // Instantiate the particle effect
            Instantiate(clearObstacle, transform.position, transform.rotation);
        }
    }

}


