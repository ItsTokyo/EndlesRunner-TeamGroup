using TMPro;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform playerPostion;
    [SerializeField] private float targetX;
    public float furthestX;
    [SerializeField] private float score;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private TMP_Text distanceUI;

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


        score = distanceTag * distanceAcceleration * timeScaler.timeScale * Time.deltaTime;

        distanceAcceleration += .1f * Time.deltaTime;

        scoreDisplay = Mathf.RoundToInt(score);

        scoreUI.text = "Score: " + scoreDisplay.ToString();
        distanceUI.text = "Distance: " + furthestX.ToString() + "m";
    }
}
