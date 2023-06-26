using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public delegate void UnitEventHandler();

    public static event UnitEventHandler onEnemySpawn;
    public static event UnitEventHandler onEnemyDestroy;

    public static void NewEnemyCreated()
    {
        if (onEnemySpawn != null)
        {
            onEnemySpawn();
        }
    }
    public static void EnemyDead()
    {
        if (onEnemyDestroy != null)
        {
            onEnemyDestroy();
        }
    }
}
