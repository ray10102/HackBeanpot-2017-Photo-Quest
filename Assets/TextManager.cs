using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public Text[] texts;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TriggerText(int n) {
        texts[n].gameObject.SetActive(true);
    }
}
