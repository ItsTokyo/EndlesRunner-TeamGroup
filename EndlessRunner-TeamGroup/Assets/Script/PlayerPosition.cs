using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform playerPostion;
    [SerializeField] private float targetX;
    public float furthestX;
    public float score;
    public int collectableValue;

    [SerializeField] private int scoreDisplay;

    [SerializeField] private float distanceTag;
    [SerializeField] private float distanceAcceleration;
    [SerializeField] private TimerScaler timeScaler;
    void Start()
    {
        if (playerPostion != null)
        {
            furthestX = playerPostion.position.x;
        }
    }


    void FixedUpdate()
    {

        if (playerPostion != null)
        {
            targetX = playerPostion.position.x;
            ScoreCalculation(targetX);
        }

    }
    private void ScoreCalculation(float latestX)
    {

        if (latestX < furthestX)
        {
            return;
        }

        furthestX = latestX;

        if (furthestX == latestX)
        {
            distanceTag++;
        }


        score = distanceTag * distanceAcceleration * timeScaler.timeScale * Time.deltaTime + collectableValue;

        distanceAcceleration += .1f * Time.deltaTime;

        scoreDisplay = Mathf.RoundToInt(score);
    }
}
