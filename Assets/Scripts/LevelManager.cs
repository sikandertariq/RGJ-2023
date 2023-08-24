using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tinies;


    void Update()
    {
        tinies = GameObject.FindGameObjectsWithTag("Tiny");
        if (tinies.Length == 0)
            if (SceneManager.GetActiveScene().buildIndex == 5)  // == 6
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
