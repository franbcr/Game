using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    private static bool CanvasCreated = false;
    void Awake()
    {
        if (!CanvasCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            CanvasCreated = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
}
