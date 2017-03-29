using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public GameObject torch;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PopupTrigger() {
        anim.SetTrigger("popup");
    }

    public void AddTorch() {
        torch.SetActive(true);
    }
}
