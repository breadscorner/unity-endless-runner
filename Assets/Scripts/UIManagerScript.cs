using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject overlayPanel;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject gameStartScreen;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OpenSettingsMenu()
    {
        // Explicitly activate the settings menu and overlay
        overlayPanel.SetActive(true);
        settingsMenu.SetActive(true);

        // Deactivate the game start screen
        gameStartScreen.SetActive(false);

        Debug.Log("Settings Menu is now active");
    }

    public void CloseSettingsMenu()
    {
        // Explicitly deactivate the settings menu and overlay
        overlayPanel.SetActive(false);
        settingsMenu.SetActive(false);

        // Activate the game start screen
        gameStartScreen.SetActive(true);

        Debug.Log("Settings Menu is now inactive");
    }
}
