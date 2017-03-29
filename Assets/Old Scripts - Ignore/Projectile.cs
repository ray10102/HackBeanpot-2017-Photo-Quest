using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col) {
		GameObject obj = col.gameObject;
		if (obj.GetComponent<Attacker> ()) {
			Health targetHealth = obj.GetComponent<Health> ();
			if (targetHealth) {
				targetHealth.DealDamage (damage);
				Debug.Log ("Damaged " + obj);
				DestroyObject (gameObject);
			}
		}
	}
}
