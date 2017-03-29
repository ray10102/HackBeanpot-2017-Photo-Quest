using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	public bool anyAttackersLeft;

	private Camera myCamera;
	private StarDisplay starDisplay;
	private GameObject defenderParent;
	private GameObject currentDefender;
	private GameTimer gameTimer;
	private GameObject attackerParent;
	
	void Start () {
		myCamera = GameObject.FindObjectOfType<Camera> ();
		defenderParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		gameTimer = GameObject.FindObjectOfType<GameTimer> ();

		
		if (!defenderParent) {
			defenderParent = new GameObject ("Defenders");
		}
	}

	void OnMouseDown () {
		if (!gameTimer.isEndOfLevel) {
			currentDefender = Button.selectedDefender;
			int defenderCost = currentDefender.GetComponent<Defender> ().starCost;
			if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
				starDisplay.UseStars (defenderCost);
				Vector2 placePos = WorldPointGridSnap ();
				GameObject newDefender = Instantiate (currentDefender, placePos, Quaternion.identity) as GameObject;
				newDefender.transform.parent = defenderParent.transform;
			} else {
				Debug.Log ("Insufficient stars for purchase");
			}
		}
	}

	Vector2 WorldPointGridSnap () {
		Vector2 worldPos = CalculateMouseClickWorldPoint ();
		float worldX = worldPos.x;
		float worldY = worldPos.y;
		worldX = Mathf.Round (worldX);
		worldY = Mathf.Round (worldY);
		Vector2 newWorldPos = new Vector2 (worldX, worldY);

		return newWorldPos;
	}

	Vector2 CalculateMouseClickWorldPoint () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 thisweirdthing = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (thisweirdthing);
		
		return worldPos;
	}

	public bool AnyAttackersLeft () {
		attackerParent = GameObject.Find ("Attackers");

		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		
		foreach (Spawner spawner in spawnerArray) {
			foreach (Transform attacker in spawner.transform) {
				if (attacker) {
					return true;
				}
			}
		}

		return false;
	}
}
