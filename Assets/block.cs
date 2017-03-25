using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (var touch : Touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                Debug.Log("touch");
            }
        }
    }
}
