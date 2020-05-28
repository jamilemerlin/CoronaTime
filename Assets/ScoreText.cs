using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text TimerText;
    public bool playing;
    private float Timer;

    void Update()
    {
        if (playing == true)
        {
            Timer += Time.deltaTime;
            int score = Mathf.FloorToInt(Timer);
            TimerText.text = "Score: " + score.ToString("000");
        }
    }


}