using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScaler : MonoBehaviour
{

    [SerializeField] private int fakeTime = 0;
    private int realTimeS1 = 00;
    private int realTimeS2 = 00;
    private int realTimeM1 = 00;
    private int realTimeM2 = 00;

    [SerializeField] private TMP_Text clockSUI;
    [SerializeField] private TMP_Text clockSUI2;
    [SerializeField] private TMP_Text clockMUI;
    [SerializeField] private TMP_Text clockMUI2;

    public float timeScale = 1f;

    private void Start()
    {
        StartCoroutine(Clock());   
    }

    private IEnumerator Clock() //Is a clock for fakeTime which is how the game scales and realTime which is just a normal clock
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            fakeTime++;
            realTimeS1++;

            if (realTimeS1 >= 10)
            {
                realTimeS1 = 0;
                realTimeS2++;

                if (realTimeS2 >= 6)
                {
                    realTimeS2 = 0;
                    realTimeM1++;

                    if (realTimeM1 >= 10)
                    {
                        realTimeM1 = 0;
                        realTimeM2++;
                    }
                }
            }

            clockSUI.text = realTimeS1.ToString();
            clockSUI2.text = realTimeS2.ToString();
            clockMUI.text = realTimeM1.ToString();
            clockMUI2.text = realTimeM2.ToString();

            DifficultyScale();
        }
    }
    private void DifficultyScale()
    {
        if (fakeTime >= 10)
        {
            fakeTime = 0;
            timeScale += .5f;
        }
    }

}
