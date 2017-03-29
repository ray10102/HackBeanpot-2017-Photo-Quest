using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraButton : MonoBehaviour {

    public Sprite up, down;
    private Image sr;
    private GameObject camera;
    private Animator anim;
    private bool isUp = false;
    public CameraControllerWeb ccw;
    public Popup popup;

	// Use this for initialization
	void Start () {
        sr = GetComponent<Image>();
        camera = GameObject.Find("Camera Frame");
        anim = camera.GetComponent<Animator>();
        popup = FindObjectOfType<Popup>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sr.sprite != up) {
            Invoke("spriteUp", .15f);
        }
	}

    public void spriteDown() {
        sr.sprite = down;
    }

    public void spriteUp() {
        sr.sprite = up;
    }

    public void StepCamera() {
        anim.SetTrigger(!isUp ? "SlideUp" : "SlideDown");
        if (isUp) {
            ccw.TakePhoto();
            Invoke("Popup", 1f);
        }
		isUp = !isUp;
    }
    
    public void Popup() {
        popup.PopupTrigger();
    }
}
