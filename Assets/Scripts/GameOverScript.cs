using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreTextMesh;
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        string finalScore = PlayerPrefs.GetString("Score", "0"); 
        scoreTextMesh.text = "Score: " + finalScore;
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
