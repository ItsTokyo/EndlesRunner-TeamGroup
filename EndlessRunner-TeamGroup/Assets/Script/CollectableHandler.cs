using UnityEditor.UI;
using UnityEngine;

public class CollectableHandler : MonoBehaviour
{
    
    public GameObject player;
    public PlayerPosition playerPosition;
    public Collectable collectable;

    public void Collect(Collectable collectable)
    {
        // Type 0 collectables are score items, should just increase score by value.
        if (collectable.collectType == 0)
        {
            playerPosition.collectableValue += collectable.value;
        }
        // Type 1 collectables are powerups, either Rewind or Skip forward collectables.
        else if (collectable.collectType == 1)
        {
            // Rewind collectables re-set the player's current x value by the value, and removing all obstacles before the position.
            if (collectable.powerType == 0)
            {
                player.GetComponent<PlayerMovement>().playerPos.x -= collectable.value;
                foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
                    if (obstacle.transform.position.x <= player.GetComponent<PlayerMovement>().playerPos.x + 5)
                    {
                        Destroy(obstacle);
                    }
                player.transform.position = player.GetComponent<PlayerMovement>().playerPos;
            }
            // Skip collectables should move the player ahead, setting a new furthest X and ensuring there's no obstacle there.
            else if (collectable.powerType == 1)
            {
                player.GetComponent<PlayerMovement>().playerPos.x += collectable.value;
                foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
                    if (obstacle.transform.position.x <= player.GetComponent<PlayerMovement>().playerPos.x + 5)
                    {
                        Destroy(obstacle);
                    }
                player.transform.position = player.GetComponent<PlayerMovement>().playerPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Makes sure it's colliding with the player.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected item.");
            Collect(collectable);
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.GetComponent<PlayerPosition>();
        collectable = GetComponent<Collectable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
