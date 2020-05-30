using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreEntry
{
    public string name;
    public int score;
}

public class HighScores
{
    public List<ScoreEntry> highscoreEntryList;
}

public class HighScore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    [SerializeField] public Hashtable HighScoreInfo = new Hashtable();
    public List<ScoreEntry> ScoreList = new List<ScoreEntry>();

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Name"))
        {
            this.AddScoreEntry(PlayerPrefs.GetInt("Score"), PlayerPrefs.GetString("Name"));
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Name");
        }

        if (PlayerPrefs.HasKey("ScoreList"))
        {

            string jsonString = PlayerPrefs.GetString("ScoreList");
            HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

            ScoreList = highscores.highscoreEntryList;
        }

        float templateHeight = 30f;

        for (int i = 0; i < ScoreList.Count; i++)
        {
            ScoreEntry scoreItem = ScoreList[i];
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }

            entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;
            entryTransform.Find("ScoreText").GetComponent<Text>().text = scoreItem.score.ToString();
            entryTransform.Find("NameText").GetComponent<Text>().text = scoreItem.name;
        }
    }

    private void AddScoreEntry(int score, string name)
    {
        ScoreEntry newScoreEntry = new ScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("ScoreList");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        highscores.highscoreEntryList.Add(newScoreEntry);
        highscores.highscoreEntryList.Sort((a, b) => b.score - a.score);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("ScoreList", json);
        PlayerPrefs.Save();
    }
}
