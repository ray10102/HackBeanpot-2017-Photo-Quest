using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMap
{

    Dictionary<string, InventoryItem> itemTable;

    public ItemMap()
    {
        this.itemTable = new Dictionary<string, InventoryItem>();
        this.initMap();
    }

    // Use this for initialization
    void initMap()
    {
        //TODO dummy values to be replaced depending on output of indico api.
        string[] trashcan = new string[] { "bucket", "pail", "quilt", "comforter", "comfort", "puff", "bow tie", "bow-tie", "bowtie", "studio couch", "day bed", "ashcan", "trash can", "garbage can", "wastebin", "ash bin", "ash-bin", "ashbin", "dustbin", "trash barrel", "trash bin", "jean", "blue jean", "denim", "mortar", "bassinet" };
        string[] tables = new string[] { "drum", "membranophone", "tympan", "banjo", "folding chair", "dough", "hatchet", "miniskirt", "mini", "cardigan", "wooden spoon", "dining table", "board" };
        string[] fire = new string[] { "cinema", "movie theater", "movie theatre", "movie house", "picture palace", "coral fungus", "caldron", "cauldron" };
        string[] water = new string[] { "coffee mug", "toilet tissue", "toilet paper", "bathroom tissue", "pick", "plectrum", "plectron", "measuring cup", "paper towel" };
        string[][] itemGroups = new string[][] { trashcan, tables, fire, water };
        for (int i = 0; i < itemGroups.Length; i++)
        {
            string[] items = itemGroups[i];
            for (int j = 0; j < items.Length; j++)
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

    public InventoryItem getItem(string[] itemKeys)
    {
        foreach (string item in itemKeys)
        {
            if (this.itemTable.ContainsKey(item))
            {
                return this.itemTable[item];
            }
        }

        throw new ItemNotFoundException("Sorry that item is not in the game yet.");
    }
}


