using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public string levelToLoad = "MainLevel";
    
    void Start()
    {
        GameStates.OnMenu = true;
    }

    public void Play()
    {
        GameStates.OnMenu = false;
        GameStates.GameIsOver = false;
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
