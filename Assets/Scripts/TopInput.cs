using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopInput : MonoBehaviour {

    private Camera myCamera;
    Inventory inventory;
    GameObject objectsParent;

    // Use this for initialization
    void Start () {
        myCamera = GameObject.FindObjectOfType<Camera>();
        inventory = GameObject.FindObjectOfType<Inventory>();
        objectsParent = GameObject.Find("Objects");
        if (!objectsParent) {
            Debug.LogError("No Objects parent found");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        Debug.Log("Mouse clicked: " + Input.mousePosition);
    }
}
