using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject[] tinies;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        tinies = GameObject.FindGameObjectsWithTag("Tiny");
        if (tinies.Length == 0)
            if (SceneManager.GetActiveScene().name == "5")  // == 6
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator GameOver()
    {
        Debug.Log("hahahahah");
        yield return new WaitForSeconds(1.5f);
        gameOverMenu.SetActive(true);
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
