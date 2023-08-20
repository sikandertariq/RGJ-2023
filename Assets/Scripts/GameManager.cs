using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Reference to TextMeshPro components on buttons
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI settingsButtonText;
    public TextMeshProUGUI quitButtonText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called when the "Start" button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("1"); // Load scene named "1"
    }

    // Called when the "Settings" button is clicked
    public void OpenSettings()
    {
        // Add functionality to open settings here
    }

    // Called when the "Quit" button is clicked
    public void QuitGame()
    {
        Application.Quit();
    }
}
