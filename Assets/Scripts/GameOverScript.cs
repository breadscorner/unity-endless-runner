using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreTextMesh;
    void Start()
    {
        Setup();  // Ensure score display is set up when the scene starts
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        string finalScore = PlayerPrefs.GetString("Score", "0");  // Retrieve the saved score
        scoreTextMesh.text = "Score: " + finalScore;  // Display the score
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
