using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMap {

    Dictionary<string, InventoryItem> itemTable;

    ItemMap()
    {
        this.itemTable = new Dictionary<string, InventoryItem>();
        this.initMap();
    }

    // Use this for initialization
    void initMap () {
        //TODO dummy values to be replaced depending on output of indico api.
        string[] cups = new string[] { "coffeepot", "coffee mug" };
        string[] tables = new string[] { "table", "bench" };
        string[] fire = new string[] { "lighter", "fire" };
        string[] water = new string[] { "water", "rain" };
        string[][] itemGroups = new string[][] { cups, tables, fire, water };
        for(int i = 0; i < itemGroups.Length; i++)
        {
            string[] items = itemGroups[i];
            for(int j = 0; j < items.Length; j++)
            {
                string itemName = items[j];
                switch (i)
                {
                    case 0:
                        //TODO make sprite.
                        InventoryItem cupItem = new InventoryItem("cup", new Sprite());
                        itemTable.Add(itemName, cupItem);
                        break;
                    case 1:
                        //TODO make sprite.
                        InventoryItem tableItem = new InventoryItem("table", new Sprite());
                        itemTable.Add(itemName, tableItem);
                        break;
                    case 2:
                        //TODO make sprite.
                        InventoryItem fireItem = new InventoryItem("fire", new Sprite());
                        itemTable.Add(itemName, fireItem);
                        break;
                    case 3:
                        //TODO make sprite.
                        InventoryItem waterItem = new InventoryItem("water", new Sprite());
                        itemTable.Add(itemName, waterItem);
                        break;
                }
                }
            }
        }

    public InventoryItem getItem(string itemKey)
    {
        if (this.itemTable.ContainsKey(itemKey))
        {
            return this.itemTable[itemKey];
        }
        else
        {
            throw new ItemNotFoundException("Sorry that item is not in the game yet.");
        }
    }
		
	}
