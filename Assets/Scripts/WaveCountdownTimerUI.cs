using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountdownTimerUI : MonoBehaviour
{
    public Text waveCountdownText;

    void Update()
    {
        waveCountdownText.text = string.Format("{0:00.00}", WaveSpawner.wave_countdown);
    }
}