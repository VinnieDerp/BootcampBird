using UnityEngine;
using UnityEngine.UIElements;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private GameOverHandler _gameOverHandler;
    [SerializeField]
    private ObstacleHandler _obstacleHandler;
    public UIDocument _uiDocument;
    private Label _scoreLabel;
    private Label _highScoreLabel;
    [SerializeField]
    private int _highScore;
    public int _score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;

        _uiDocument = GetComponent<UIDocument>();

        _scoreLabel = _uiDocument.rootVisualElement.Q("Score") as Label;
        _highScoreLabel = _uiDocument.rootVisualElement.Q("HighScore") as Label;

        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;

        if (_score > _highScore)
        {
            _highScore = _score;
        }

        _scoreLabel.text = "Score: " + _score.ToString();

        _highScoreLabel.text = "High score: " + _highScore.ToString();
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("HighScore", _highScore);
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        gameObject.SetActive(false);
        //_gameOverHandler.enabled = true;
        _gameOverHandler.gameObject.SetActive(true);
    }
}
