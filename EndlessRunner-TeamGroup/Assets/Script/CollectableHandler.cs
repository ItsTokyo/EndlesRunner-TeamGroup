using UnityEngine;

public class CollectableHandler : MonoBehaviour
{

    public int collectType;
    public int powerType;
    public int value;
    public GameObject player;
    
    void Collect()
    {
        if (collectType == 0)
        {
            player.PlayerPosition.score += value;
        }
        else if (collectType == 1)
        {
            if (powerType == 0)
            {
                
            }
            else if (powerType == 1)
            {
                
            }
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindByTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
