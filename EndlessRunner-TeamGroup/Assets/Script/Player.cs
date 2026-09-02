using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public int health;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                Destroy(gameObject);
            }
        }
        /*This will trigger the collectable handler's script for collecting a score item or powerup.*/
        if (other.CompareTag("Collectable"))
        {
            
        }
    }

   
    
}

