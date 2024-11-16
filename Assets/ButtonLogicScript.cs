using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogicScript : MonoBehaviour
{
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
