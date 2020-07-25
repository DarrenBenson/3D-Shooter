using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _gameScoreText;
    [SerializeField] private int _gameScore;
    [SerializeField] private int _highScore;


    private void OnEnable()
    {
        GameEventManager.OnStartGame += ResetGameScore;
        GameEventManager.OnUpdateScore += UpdateScore;
        GameEventManager.OnPlayerDestroyed += CheckNewHighScore;
    }

    private void OnDisable()
    {
        GameEventManager.OnStartGame -= ResetGameScore;
        GameEventManager.OnUpdateScore -= UpdateScore;
        GameEventManager.OnPlayerDestroyed -= CheckNewHighScore;
    }

    private void Start()
    {
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        PlayerPrefs.GetInt("highScore", 0);
        DisplayHighScore();
    }

    private void CheckNewHighScore()
    {
        if (_gameScore > _highScore)
        {
            PlayerPrefs.SetInt("highScore", _gameScore);
            DisplayHighScore();
        }
    }

    private void UpdateScore(int incrementAmount)
    {
        _gameScore += incrementAmount;
        DisplayGameScore();
    }

    private void ResetGameScore()
    {
        _gameScore = 0;
        DisplayGameScore();
    }

    private void DisplayGameScore()
    {
        _gameScoreText.text = _highScore.ToString();
    }

    private void DisplayHighScore()
    {
        _highScoreText.text = _highScore.ToString();
    }


}
