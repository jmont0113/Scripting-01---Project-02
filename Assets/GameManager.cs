using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        int desiredLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(desiredLevelIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
