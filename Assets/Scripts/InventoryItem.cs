using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {

    string itemName;
    Sprite image;

    public InventoryItem() { }

    public InventoryItem(string itemName, Sprite image)
    {
        this.itemName = itemName;
        this.image = image;
    }

    public bool itemEquals(InventoryItem that)
    {
       return this.itemName == that.itemName;
    }
}
