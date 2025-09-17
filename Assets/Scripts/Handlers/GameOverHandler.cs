using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]    private GameHandler _gameHandler;
    private UIDocument _uiDocument;
    private Button _restartButton;
    private Label _scoreLabel;
    private Label _highScoreLabel;
    private Label _gameOverLabel;

    void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();

        _restartButton = _uiDocument.rootVisualElement.Q("ReturnToMenuButton") as Button;
        _restartButton.RegisterCallback<ClickEvent>(OnRestartButtonClicked);
        _restartButton.text = "Restart the Game";

        _scoreLabel = _uiDocument.rootVisualElement.Q("Score") as Label;
        _scoreLabel.text = "Score: " + _gameHandler._score.ToString();

        _highScoreLabel = _uiDocument.rootVisualElement.Q("HighScore") as Label;
        _highScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        _gameOverLabel = _uiDocument.rootVisualElement.Q("GameOver") as Label;
        _gameOverLabel.text = "Game Over!";
    }

    void OnDisable()
    {
        _restartButton.UnregisterCallback<ClickEvent>(OnRestartButtonClicked);
    }

    void OnRestartButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Reset");
    }
}