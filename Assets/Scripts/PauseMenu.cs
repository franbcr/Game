using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public string mainMenu = "MainMenu";
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
            GameStates.OnMenu = true;
        }
        else
        {
            Time.timeScale = 1f;
            GameStates.OnMenu = false;
        }

        
    }

    public void Retry()
    {
        Toggle();
        PlayerStats playerStats = gameObject.AddComponent(typeof(PlayerStats)) as PlayerStats;
        playerStats.DefaultPlayerStats();
        GameManager.instance.ResetWaveNumber();
        GameManager.instance.ResetWaveTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene(mainMenu);
    }
}
