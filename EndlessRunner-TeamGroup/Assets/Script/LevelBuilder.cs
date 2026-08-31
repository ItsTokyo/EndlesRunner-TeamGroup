using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> easySegments;
    [SerializeField] private List<GameObject> mediumSegments;
    [SerializeField] private List<GameObject> hardSegments;

    [SerializeField] private float spawnthreshold;
    [SerializeField] private float spawnDistance;

    [SerializeField] private PlayerPosition playerPosition;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (playerPosition.furthestX + spawnthreshold >= playerPosition.furthestX + spawnDistance)
        {
            SpawnNextSegment();
        }
    }

    private void SpawnNextSegment()
    {

    }
    GameObject ChooseSegment()
    {
        float difficulty = playerPosition.furthestX;

        if (difficulty < 250f)
        {
            return easySegments[Random.Range(0, easySegments.Count)];
        }
        else if (difficulty < 500f)
        {
            return mediumSegments[Random.Range(0, mediumSegments.Count)];
        }
        else
        {
            return hardSegments[Random.Range(0, hardSegments.Count)];
        }
            
    }
}
