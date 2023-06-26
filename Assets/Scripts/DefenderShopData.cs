using UnityEngine;

[CreateAssetMenu(menuName = "Data/DefenderShopData")]
public class DefenderShopData : ScriptableObject
{
    public GameObject prefab;
    public int cost;
    public int sellPrice;
    public int upgradeCost;
}