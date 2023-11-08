using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    GameObject goScore;
    GameObject goHighScore;

    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore"); // Fixed the typo here
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Ensure PlayerPrefs changes are saved
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        goScore = GameObject.Find("txtScore");
        scoreText = goScore.GetComponent<Text>();

        goHighScore = GameObject.Find("highScore"); // Fixed the typo here
        highScoreText = goHighScore.GetComponent<Text>();

        highScoreText.text = "HIGH SCORE: " + highScore.ToString("#,0");
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = "SCORE: " + score.ToString("#,0");
    }

    public void TRY_TO_SET_HIGHSCORE(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "HIGH SCORE: " + highScore.ToString("#,0");
        }
    }
}
