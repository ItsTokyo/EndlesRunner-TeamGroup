using System.Collections;
using UnityEngine;

public class TimerScaler : MonoBehaviour
{

    [SerializeField] private int realTime = 0;
    [SerializeField] private float timeScale = 1f;
    [SerializeField] private float score = 0f;

    private void Start()
    {
        StartCoroutine(Clock());   
    }

    private IEnumerator Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            realTime++;
            DifficultyScale();
            ScoreCalculation(1f);
        }
    }
    private void DifficultyScale()
    {
        if (realTime >= 10)
        {
            realTime = 0;
            timeScale += .5f;
        }
    }

    private void ScoreCalculation(float points)
    {
        float total = (timeScale * points);
        score += total;
    }
}
