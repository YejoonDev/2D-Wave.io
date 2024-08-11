using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject textTitle;
    [SerializeField] private GameObject textPlay;
    [SerializeField] private GameObject buttonContinue;

    [SerializeField] private TextMeshProUGUI textBestScore;
    [SerializeField] private GameObject textScoreLabel;
    [SerializeField] private TextMeshProUGUI textScoreValue;
    
    public bool IsGameOver { private set; get; } = false;
    private int _currentScore;

    private IEnumerator Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textBestScore.text = $"<size=50>Best Score</size>\n<size=100>{bestScore}</size>";
        
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        textTitle.SetActive(false);
        textPlay.SetActive(false);
        textScoreValue.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;

        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (_currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _currentScore);
            textBestScore.text = $"<size=50>Best Score</size>\n<size=100>{_currentScore}</size>";
        }
        
        buttonContinue.SetActive(true);
        textScoreLabel.SetActive(true);
        
        
    }

    public void IncreaseScore(int score)
    {
        _currentScore += score;
        textScoreValue.text = _currentScore.ToString();
    }

    public void ContinueScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
