using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool OnMenu;

    public GameObject gameOverUI;

    void Start()
    {
        if (GameIsOver)
        {
            GameIsOver = false;
            OnMenu = false;
        }
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        OnMenu = true;

        gameOverUI.SetActive(true);
    }
}
