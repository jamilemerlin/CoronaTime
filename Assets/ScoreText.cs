using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text TimerText;
    public bool playing;
    public float Timer;

    void Update()
    {
        if (playing == true)
        {
            Timer += Time.deltaTime;
            int score = Mathf.FloorToInt(Timer);
            TimerText.text = "Time: " + score.ToString("000");
        }
    }


}