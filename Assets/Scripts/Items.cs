using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Dictionary<int, Item> itemTable = new Dictionary<int, Item>();
    // Start is called before the first frame update
    void Start() 
    {
        AddItem(1, "Shield", Item.ItemType.ArmourResistance);
        AddItem(2, "Potion", Item.ItemType.Consumable);
        ListAllItems();
        RemoveItem(2);
        ListAllItems();
    }

    public class Item
    {
        public enum ItemType
        {
            Consumable,
            ArmourResistance,
            MagicResistance
        }
        public int id;
        public string itemName;
        public ItemType type;
        
    }

    public void AddItem(int id, string name, Item.ItemType itemType)
    {
        if (itemTable.ContainsKey(id))
        {
            return;
        }
        else
        {
            var newItem = new Item();
            newItem.id = id;
            newItem.itemName = name;
            newItem.type = itemType;

            itemTable.Add(id, newItem);
        }
    }

    public void RemoveItem(int id)
    {
        if (itemTable.ContainsKey(id))
        {
            itemTable.Remove(id);
        }
    }

    public Item GetItemInfo(int id)
    {
        if (itemTable.TryGetValue(id, out Item item))
        {
            return item;
        }
        else
        {
            return null;
        }
    }
    public void ListAllItems()
    {
        foreach (KeyValuePair<int, Item> item in itemTable)
        {
            //Debug.Log("ID: " + item.Key + " Name: " + item.Value.itemName + " Type: " + item.Value.type);
        }
    }
 }
