using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// [SerializeField] private HurdleGenerator hurdleGenerator = null;

// private void Awake()
// {
//     //anim = GetComponent<Animator>();
//     //anim = runnerObject.GetComponent<RunnerScript>();
// }
public class HurdleScript : MonoBehaviour
{
    // Private methods
    private Animator anim;
    float score;

    // Public methods
    [SerializeField] public TextMeshProUGUI scoreTextMesh;
    [SerializeField] public TextMeshProUGUI highScoreTM;
    public HurdleGenerator hurdleGenerator;
    private RunnerScript runnerScript;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        runnerScript = player.GetComponent<RunnerScript>();  // Access RunnerScript on the player
    }

    void Update()
    {
        transform.Translate(Vector2.left * hurdleGenerator.CurrentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextHurdle"))
        {
            hurdleGenerator.generateNextHurdleWithGap();
        }
        if (collision.gameObject.CompareTag("FinishHurdle"))
        {
            Destroy(this.gameObject);
        }
    }

    public void HighScore()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        int finalScore = PlayerPrefs.GetInt("Score", 0);
        scoreTextMesh.text = "Score: " + finalScore;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreTM.text = "High Score: " + highScore;
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            float finalScore = runnerScript.GetScore();
            int intFinalScore = Mathf.FloorToInt(finalScore);
            PlayerPrefs.SetInt("Score", intFinalScore);

            // Check and set High Score
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if (intFinalScore > highScore)
            {
                PlayerPrefs.SetInt("HighScore", intFinalScore);
            }

            PlayerPrefs.Save();
            SceneManager.LoadScene("Game Over Scene");
            Debug.Log("Final Score Saved: " + intFinalScore);
        }
    }
}
