using UnityEngine;
using Unity.Collections;
using System.Collections;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject introUI;
    public GameObject menuUI;
    public GameObject gameOverUI;
    public float timeIntroSkip = 5f;

    public TextMeshProUGUI score;
    public GameManager gameManager;
    private void Start()
    {
        SetPanels();
        OnLoadIntro();
        gameManager.onAddPoints += UpdateScore;
        gameManager.onGameOver += GameOver;
    }
    void SetPanels()
    {
        introUI.SetActive(true);
        menuUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
    public void SkipsIntro()
    {
        introUI.SetActive(false);
        menuUI.SetActive(true);
        StopCoroutine(LoadIntro());
    }
    public void OnLoadIntro()
    {
        StartCoroutine(LoadIntro());
    }
    IEnumerator LoadIntro()
    {
        yield return new WaitForSecondsRealtime(timeIntroSkip);
        SkipsIntro();
    }
    public void StartGame()
    {
        menuUI.SetActive(false);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void UpdateScore()
    {
        score.text = "Score : " + gameManager.score + "/6";
    }
}
