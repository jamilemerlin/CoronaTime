using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text Text;
    public Text SubText;
    public Text GameOverScore;
    public ScoreText scoreText;
    public bool IsDead;



    public void GameOver()
    {
        Text.gameObject.SetActive(false);
        SubText.gameObject.SetActive(false);
        GameOverScore.gameObject.SetActive(false);
        IsDead = false;

    }

    void Update()
    {
        if (IsDead && Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    public void SetGame()
    {
        IsDead = true;
        Text.gameObject.SetActive(true);
        SubText.gameObject.SetActive(true);
        GameOverScore.gameObject.SetActive(true);
        Text.text = "Game Over";
        SubText.text = "Press Space to Try Again";
        GameOverScore.text = "Score: " + Mathf.FloorToInt(scoreText.Timer).ToString("000");
        scoreText.gameObject.SetActive(false);
    }

    public void Restart()
    {
        IsDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
