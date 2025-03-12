using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const int MainScene = 0;

    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _playerCollisionHandler.GameOver += GameReset;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _playerCollisionHandler.GameOver -= GameReset;
    }  

    private void GameReset()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        SceneManager.LoadScene(MainScene);
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        Time.timeScale = 1;
    }
}