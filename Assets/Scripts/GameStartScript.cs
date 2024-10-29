using UnityEngine;
using UnityEngine.SceneManagement;

// Exists solely for game menu

public class GameStartScript : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("City Hurdling Scene");
    }
}