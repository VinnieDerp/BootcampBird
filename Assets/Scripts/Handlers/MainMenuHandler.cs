using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameHandler _gameHandler;
    [SerializeField]
    private GameOverHandler _gameOverHandler;
    private UIDocument _uiDocument;
    private Button _startButton;
    private Label _highScoreLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();

        _startButton = _uiDocument.rootVisualElement.Q("StartButton") as Button;
        _startButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);

        _highScoreLabel = _uiDocument.rootVisualElement.Q("HighScore") as Label;
        _highScoreLabel.text += PlayerPrefs.GetInt("HighScore", 0).ToString();

        _gameOverHandler.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        _startButton.UnregisterCallback<ClickEvent>(OnStartButtonClicked);
    }

    void OnStartButtonClicked(ClickEvent evt)
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Debug.Log("Game Started");
    }
}
