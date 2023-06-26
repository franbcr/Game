using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{
    private static bool startNodeCreated = false;
    void Awake()
    {
        if (!startNodeCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            startNodeCreated = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
}
