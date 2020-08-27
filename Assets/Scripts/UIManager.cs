using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] string gameExperience = "ExperienceGained";
    [SerializeField] Text scoreText;
    [SerializeField] Text highScore;
    [SerializeField] int Score = 0;
    private int scoreNumber = 0;

    private void Start()
    {
        scoreText.text = "Score: " + scoreNumber;

        highScore.text = PlayerPrefs.GetInt(gameExperience, 0).ToString();

        // update the UI
        UpdateUI();
    }

    public void AddToScore(int _scoreToAdd)
    {
        // add to the current score
        Score += _scoreToAdd;
        // Update the UI
        UpdateUI();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Save Data
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Score += 5;
            UpdateScore();
        }

    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + Score;
    }

    public void UpdateUI()
    {
        scoreText.text = Score.ToString();
    }

    void SaveData()
    {
        if (Score > PlayerPrefs.GetInt(gameExperience, 0))
        {
            PlayerPrefs.SetInt(gameExperience, Score);
            highScore.text = Score.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
}
