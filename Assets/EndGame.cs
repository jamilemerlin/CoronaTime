using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text Text;
    public Text SubText;
    public Text GameOverScore;
    public ScoreText scoreText;
    public bool IsDead;



    void Start()
    {
        Text.gameObject.SetActive(false);
        SubText.gameObject.SetActive(false);
        GameOverScore.gameObject.SetActive(false);
        IsDead = false;

    }

    void Update()
    {

    }
    public void SetGame()
    {
        if (!IsDead)
        {
            IsDead = true;
            Text.gameObject.SetActive(true);
            SubText.gameObject.SetActive(true);
            GameOverScore.gameObject.SetActive(true);
            Text.text = "Game Over";
            SubText.text = "Press Enter to Try Again";
            GameOverScore.text = "Score: " + Mathf.FloorToInt(scoreText.Timer).ToString("000");
            scoreText.gameObject.SetActive(false);
        }
    }
}
