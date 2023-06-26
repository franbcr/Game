using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardMageLVL1Prefab;
    public GameObject standardMageLVL2Prefab;
    public GameObject buildEffect;

    private DefenderShopData mageToBuild;

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
    public bool CanBuild { get { return mageToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= mageToBuild.cost; } }

    public void BuildMageOn (NodeManager node)
    {
        if (PlayerStats.money < mageToBuild.cost)
        {
            return;
        }

        PlayerStats.money -= mageToBuild.cost;

        GameObject mage = Instantiate(mageToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.mage = mage;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void SelectMageToBuild(DefenderShopData mage)
    {
        mageToBuild = mage;
    }
}