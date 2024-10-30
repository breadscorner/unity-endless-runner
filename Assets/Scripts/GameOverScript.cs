using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreTextMesh;
    [SerializeField] public TextMeshProUGUI highScoreTextMesh;
    void Start()
    {
        Setup();
    }

        public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        int finalScore = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreTextMesh.text = "Score: " + finalScore;
        highScoreTextMesh.text = "High Score: " + highScore;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("City Hurdling Scene");
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Start Scene");
    }
}
