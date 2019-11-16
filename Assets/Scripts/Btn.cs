using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    public static Btn Instance;
    public Text DisplayScore;
    [SerializeField] private GameObject PausePanel, GameOverPanel;
    private bool isGameOver = false;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PauseButton()
    {
        if (!isGameOver)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void RestartButton()
    {
        ScoreScript.Score = 0;
        isGameOver = false;
        GameOverPanel.SetActive(false);
        HeartScript.currentHeart = 3;
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("End");
    }

    public void showGameOverPanel()
    {
        DisplayScore.text = "Score:" + ScoreScript.Score.ToString();
        isGameOver = true;
        GameOverPanel.SetActive(true);
    }


}
