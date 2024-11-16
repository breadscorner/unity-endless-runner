using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private TextMeshProUGUI highScoreTextMesh;
    [SerializeField] private GameObject highScorePromptPanel;
    [SerializeField] private TMP_InputField nameInputField;

    private int finalScore;

    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;


        finalScore = PlayerPrefs.GetInt("Score", 0);
        int highScore = HighScoreManager.Instance.GetHighScore();
        string highScoreName = HighScoreManager.Instance.GetHighScoreName();


        scoreTextMesh.text = "Score: " + finalScore;
        highScoreTextMesh.text = "High Score: " + highScore + " " + highScoreName;

        if (finalScore > highScore)
        {
            highScorePromptPanel.SetActive(true);
        }
        else
        {
            highScorePromptPanel.SetActive(false);
        }
    }

    public void OnSubmitHighScore()
    {
        // Delegate high score saving to the HighScoreManager
        string playerName = nameInputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player"; 
        }

        HighScoreManager.Instance.SubmitHighScore(finalScore, playerName);

        // Update the high score display
        int highScore = HighScoreManager.Instance.GetHighScore();
        highScoreTextMesh.text = "High Score: " + highScore + " by " + HighScoreManager.Instance.GetHighScoreName();

        highScorePromptPanel.SetActive(false);
    }
}
