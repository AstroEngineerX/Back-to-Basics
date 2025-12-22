using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Singleton pattern

    public GameObject levelClearedBanner; // Assign a UI panel or image here
    public AudioClip levelClearedSFX; // Assign your win sound effect
    private AudioSource audioSource;
    public GameObject RestartButton; // Assign your restart button here

    private int collectiblesRemaining;

    void Awake()
    {
        if (instance == null)
            instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        levelClearedBanner.SetActive(false); // Hide banner initially

        
        int collectibleCount = GameObject.FindGameObjectsWithTag("Collectible").Length;
        LevelManager.instance.SetCollectibleCount(collectibleCount);
        
    }

    public void SetCollectibleCount(int count)
    {
        collectiblesRemaining = count;
    }

    public void CollectibleCollected()
    {
        collectiblesRemaining--;

        if (collectiblesRemaining <= 0)
        {
            LevelCleared();
        }
    }

    private void LevelCleared()
    {
        levelClearedBanner.SetActive(true);

        if (levelClearedSFX != null)
        {
            audioSource.PlayOneShot(levelClearedSFX);
        }

        Debug.Log("Level cleared!");

        RestartButton.SetActive(true);
    }
}
