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
    
    [SerializeField] private GameObject textScoreLabel;
    [SerializeField] private TextMeshProUGUI textScoreValue;
    
    public bool IsGameOver { private set; get; } = false;
    private int _currentScore;

    private IEnumerator Start()
    {
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
        buttonContinue.SetActive(true);
        textScoreLabel.SetActive(true);
        
        IsGameOver = true;
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
