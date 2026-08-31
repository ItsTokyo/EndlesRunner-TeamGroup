using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> easySegments;
    [SerializeField] private List<GameObject> mediumSegments;
    [SerializeField] private List<GameObject> hardSegments;

    [SerializeField] private float spawnthreshold;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float nextSpawn;

    [SerializeField] private PlayerPosition playerPosition;
    private void Start()
    {
        nextSpawn = spawnDistance;
    }
    void Update()
    {
        if (playerPosition.furthestX + spawnthreshold >= nextSpawn)
        {
            SpawnNextSegment();
        }
    }
    private void SpawnNextSegment()
    {
        GameObject levelSegment = ChooseSegment();

        Instantiate(levelSegment, new Vector3(nextSpawn, 0f, 0f), Quaternion.identity);

        nextSpawn += spawnDistance;
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
