using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    private void Awake()
    {
        // Ensure only one instance of HighScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Get the current high score.
    /// </summary>

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    /// <summary>
    /// Get the name of the player who achieved the high score.
    /// </summary>

    public string GetHighScoreName()
    {
        return PlayerPrefs.GetString("HighScoreName", "None");
    }

    /// <summary>
    /// Save a new high score and player name.
    /// </summary>
    
    /// <param name="score">The new high score.</param>
    /// <param name="playerName">The name of the player.</param>

    public void SubmitHighScore(int score, string playerName)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetString("HighScoreName", playerName);
        PlayerPrefs.Save();
    }
}
