using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int waveNumber;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
    }

    public void ResetWaveNumber()
    {
        waveNumber = 0;
    }

    public void ResetWaveTime()
    {
        WaveSpawner.wave_countdown = 0;
    }

    public int GetWaveNumber()
    {
        return waveNumber;
    }

    public void IncreaseWaveNumber(int amount)
    {
        waveNumber += amount;
    }
}