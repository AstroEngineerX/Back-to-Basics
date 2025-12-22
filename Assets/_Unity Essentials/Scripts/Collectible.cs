using UnityEngine;

public class Collectible : MonoBehaviour
{
    private float rotationSpeed = 180.0f; // Set rotation speed for collectible.
    public GameObject onCollectEffect;
    public AudioClip collectSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Rotate collectible around the Y-axis.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//If the “other” GameObject that collided with me has the Player tag, then execute the code inside the brackets.
        {
            // Play the collect sound effect
            if (collectSFX != null)
            {
                AudioSource.PlayClipAtPoint(collectSFX, transform.position);
            }

            Destroy(gameObject);
            // instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
        
    }
}
