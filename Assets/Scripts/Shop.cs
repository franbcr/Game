using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public DefenderShopData mageLVL1;
    public DefenderShopData mageLVL2;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectMageLVL1()
    {
        buildManager.SelectMageToBuild(mageLVL1);
    }

    public void SelectMageLVL2()
    {
        buildManager.SelectMageToBuild(mageLVL2);
    }
}
