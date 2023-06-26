using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 50;

    public static int lives;
    public int startLives = 5;

    public static int armor;
    public int startArmor = 100;

    public static int elementalArmor;
    public int startElementalArmor = 100;

    public static int moneyDrop = 50;

    private void Start()
    {
        DefaultPlayerStats();
        GameEvents.onEnemyDestroy += EnemyMoneyDrop;
    }

    private void OnDisable()
    {
        GameEvents.onEnemyDestroy -= EnemyMoneyDrop;
    }

    public void DefaultPlayerStats()
    {
        money = startMoney;
        lives = startLives;
        armor = startArmor;
        elementalArmor = startElementalArmor;
    }

    public void EnemyMoneyDrop()
    {
        money += moneyDrop;
    }
}
