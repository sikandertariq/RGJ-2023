using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Called when the "Start" button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("1"); // Load scene named "1"
    }

    // Called when the "Quit" button is clicked
    public void QuitGame()
    {
        Application.Quit();
    }
}
