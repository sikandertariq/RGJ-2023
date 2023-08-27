using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TowerHealth towerHealth;

    [SerializeField] private GameObject[] tinies;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject joyStick;

    [SerializeField] private bool isGameOver;

    private void Start()
    {
        towerHealth = GameObject.Find("Tower").GetComponent<TowerHealth>();
        isGameOver = false;
    }
    void LateUpdate()
    {
        tinies = GameObject.FindGameObjectsWithTag("Tiny");
        if (tinies.Length == 0)
            if (SceneManager.GetActiveScene().name == "5")  // == 6
            {
                Debug.Log("before loading: " + SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(0);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (towerHealth.currentHealth <= 0 && !isGameOver)
            StartCoroutine(nameof(GameOver));
    }
    public IEnumerator GameOver()
    {
        isGameOver = true;
        Debug.Log("hahahahah");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("hahahahahzzzzzzzzzzzz");
        gameOverMenu.SetActive(true);
        joyStick.SetActive(false);
        pauseBtn.SetActive(false);
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
