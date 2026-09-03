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
        //This math equation is what builds the level. Values are entered into the hiearchy and the level will instanciate that distance away.
        if (playerPosition.furthestX + spawnthreshold >= nextSpawn)
        {
            SpawnNextSegment();
        }
    }
    private void SpawnNextSegment()
    {
        GameObject levelSegment = ChooseSegment();

        Instantiate(levelSegment, new Vector3(nextSpawn, 5.6219f, -13.33663f), Quaternion.identity);

        nextSpawn += spawnDistance;
    }
    GameObject ChooseSegment()
    {
        //An if else statement determining which level segement will be used

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
