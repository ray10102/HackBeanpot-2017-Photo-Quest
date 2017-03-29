using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;

	void Start () {
		selectedDefender = null;
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
		}

		costText = GetComponentInChildren<Text> ();
		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
		}
		selectedDefender = defenderPrefab;
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
