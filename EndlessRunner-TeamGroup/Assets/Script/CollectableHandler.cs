using UnityEngine;

public class CollectableHandler : MonoBehaviour
{

    public int collectType;
    public int powerType;
    public int value;
    public GameObject player;
    
    void Collect()
    {
        // Type 0 collectables are score items, should just increase score.
        if (collectType == 0)
        {
            
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
