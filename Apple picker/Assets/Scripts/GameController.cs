using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public TextMeshProUGUI ScoreText;

    float tickTimer = 1060f;

    public int totalApples;
    public int toatalLogs;
    public int _highScore;

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if(tickTimer > 0)
        {
            tickTimer -= Time.deltaTime;
            UpdateTimeText();
            UpdateScoreText();
        }
        else
        {
            if(totalApples > _highScore)
            {
                _highScore = totalApples;
                PlayerPrefs.SetInt("HighScore", _highScore);
            }
            SceneManager.LoadScene("Menu");
        }
        
    }

    void UpdateTimeText()
    {
        if (tickTimer < 0) tickTimer = 0;
        float minutes = Mathf.FloorToInt(tickTimer / 60);
        float seconds = Mathf.FloorToInt(tickTimer % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void UpdateScoreText()
    {
        ScoreText.text = totalApples.ToString();
    }
}
