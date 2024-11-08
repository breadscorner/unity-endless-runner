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

    public void ToggleSettingsMenu()
    {
        bool isActive = !settingsMenu.activeSelf;
        overlayPanel.SetActive(isActive);
        settingsMenu.SetActive(isActive);
        gameStartScreen.SetActive(!isActive);

        Debug.Log("Settings Menu is now " + (isActive ? "active" : "inactive"));
    }
}
