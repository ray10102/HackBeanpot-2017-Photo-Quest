﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            Debug.Log("touch");
        }
    }
}
