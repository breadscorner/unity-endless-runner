using UnityEngine;
using UnityEngine.SceneManagement;

public class HurdleScript : MonoBehaviour
{
    [SerializeField] public HurdleGenerator hurdleGenerator;
    private RunnerScript runnerScript;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        runnerScript = player.GetComponent<RunnerScript>();
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
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            float finalScore = runnerScript.GetScore();
            int intFinalScore = Mathf.FloorToInt(finalScore);

            // Save the current score
            PlayerPrefs.SetInt("Score", intFinalScore);
            PlayerPrefs.Save();

            // Load the Game Over Scene
            SceneManager.LoadScene("Game Over Scene");
        }
    }
}
