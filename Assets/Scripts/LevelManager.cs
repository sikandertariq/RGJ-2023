using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tinies;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        tinies = GameObject.FindGameObjectsWithTag("Tiny");
        if (tinies.Length == 0)
            if (SceneManager.GetActiveScene().name == "5")  // == 6
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnClick_PauseBtn()
    {
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void OnClick_Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
