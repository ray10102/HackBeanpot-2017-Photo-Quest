using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestructableItemPackage
{
    public InventoryItem item;
    public GameObject destructableItem;

	public DestructableItemPackage(InventoryItem item, GameObject destructableItem)
	{
        this.item = item;
        this.destructableItem = destructableItem;
	}
}
