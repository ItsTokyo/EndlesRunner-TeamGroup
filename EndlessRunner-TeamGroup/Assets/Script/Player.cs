using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] public static int health;
    public AudioSource collectSound;
    public AudioSource deathSound;
    public AudioSource hurtSound;
    public GameObject deathScreen;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log(health);
            health -= 1;
            if (health <= 0)
            {
                deathSound.Play();
                deathScreen.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                {
                    hurtSound.Play();
                }
            }
        }

        if (other.CompareTag("Collectable"))
        {
            collectSound.Play();
        }
        
        /*This will trigger the collectable handler's script for collecting a score item or powerup.*/
    }

   
    
}

