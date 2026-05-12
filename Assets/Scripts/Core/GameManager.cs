using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int maxScore = 6;

    public Action onAddPoints;
    public Action onGameOver;
    private void Start()
    {
        onAddPoints?.Invoke();
    }
    public void AddScore()
    {
        score += 1;
        Debug.Log("Score: " + score);

        onAddPoints?.Invoke();

        if (score >= maxScore)
        {
            onGameOver?.Invoke();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}