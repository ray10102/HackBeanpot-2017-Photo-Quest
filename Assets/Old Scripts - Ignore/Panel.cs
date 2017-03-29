using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

	public float fadeSpeed = 1;

	private Image fadePanel;
	private Color currentColor;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		currentColor = Color.black;
		fadePanel.color = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeSpeed) {
			float alphaChange = Time.deltaTime / fadeSpeed;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}
}
