using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerPosition : MonoBehaviour
{
    public Transform playerPostion;
    [SerializeField] private float targetX;
    [SerializeField] private float furthestX;
    [SerializeField] private float score;

    [SerializeField] private TimerScaler timeScaler;
    void Start()
    {
          
    }


    void Update()
    {
      
        if (playerPostion != null)
        {
            ScoreCalculation(targetX = playerPostion.position.x);
        }

    }
    private void ScoreCalculation(float latestX)
    {

        if (latestX < furthestX)
        {
            return;
        }

        furthestX = latestX;

        score = (int)furthestX * timeScaler.timeScale;
        
    }
}
