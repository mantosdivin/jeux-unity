using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 180;
    public Text timertext;
    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeDsiplay)
    {
        if(timeDsiplay < 0)
        {
            timeDsiplay = 0;
        }
        float minute = Mathf.FloorToInt(timeDsiplay / 60);
        float second = Mathf.FloorToInt(timeDsiplay % 60);
        timertext.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
