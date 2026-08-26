using System.Collections;
using UnityEngine;

public class TimerScaler : MonoBehaviour
{

    [SerializeField] private int realTime = 0;
    public float timeScale = 1f;

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
        }
    }
    private void DifficultyScale()
    {
        if (realTime >= 1)
        {
            realTime = 0;
            timeScale += .5f;
        }
    }

}
