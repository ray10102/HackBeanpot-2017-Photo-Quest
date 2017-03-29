using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator anim;
	private Spawner mySpawner;

	void Start () {
		anim = GetComponent<Animator> ();
		SetMyLaneSpawner ();
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}
	}

	void Update () {
		if (IsAttackerAheadInLane ()) { 
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	}

	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}


	bool IsAttackerAheadInLane () {
		if (mySpawner.transform.childCount <= 0) {
			return false;
		} else {
			foreach (Transform child in mySpawner.transform) {
				if (child.transform.position.x >= transform.position.x) {
					return true;
				}
			}

			return false;
		}
	}

	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				mySpawner = spawner;
				return;
			}
		}

		Debug.LogError (name + " can't find spawner in lane");
	}
}
