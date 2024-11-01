using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/* 
Add name input for high score
Use PlayerPrefs for storing the name along with the score
*/

public class GameOverScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextMesh;
    [SerializeField] TextMeshProUGUI highScoreTextMesh;
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

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Start Scene");
    }
}
