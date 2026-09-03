using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health > 0)
        {
            
        transform.position = new Vector3(player.transform.position.x, 7f, player.transform.position.z - 25f);
        }
    }
}
