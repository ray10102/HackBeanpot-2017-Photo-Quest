using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelection : MonoBehaviour {

    public bool selected;
    public GameObject highlight;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouse() {
        highlight.SetActive(true);
    }
}
