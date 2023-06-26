using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public string mainMenu = "MainMenu";
    public string mainLevel = "MainLevel";

    public void gameOverToggle()
    {
        gameOverMenu.SetActive(!gameOverMenu.activeSelf);

        if (gameOverMenu.activeSelf)
        {
            //Freeze the time
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
        gameOverToggle();
        PlayerStats playerStats = gameObject.AddComponent(typeof(PlayerStats)) as PlayerStats;
        playerStats.DefaultPlayerStats();
        GameManager.instance.ResetWaveNumber();
        GameManager.instance.ResetWaveTime();
        SceneManager.LoadScene(mainLevel);
    }

    public void Menu()
    {
        gameOverToggle();
        SceneManager.LoadScene(mainMenu);
    }
}
