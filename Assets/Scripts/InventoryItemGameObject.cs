using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wrapper class for InventoryItem
public class InventoryItemGameObject : MonoBehaviour {

    private InventoryItem itemValue;
    GameObject player;

	// Use this for initialization
	void Start()
    {
        GameObject.FindGameObjectWithTag("player");
    }

    public void SetItemValue(InventoryItem itemValue)
    {
        this.itemValue = itemValue;
    }

		
	}
	

