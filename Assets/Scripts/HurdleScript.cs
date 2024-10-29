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
    [SerializeField] public TextMeshProUGUI ScoreText;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;  
            float finalScore = runnerScript.GetScore();  
            PlayerPrefs.SetString("Score", Mathf.FloorToInt(finalScore).ToString()); 
            PlayerPrefs.Save(); 
            SceneManager.LoadScene("Game Over Scene");  
            Debug.Log("Final Score Saved: " + finalScore);
        }
    }
}
