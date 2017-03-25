using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float seenEverySeconds;

	private float moveSpeed;
	private GameObject currentTarget;
	private Animator anim;


	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D () {
		Debug.Log (name + "trigger entered");
	}

	public void setSpeed (float speed) {
		moveSpeed = speed;
	}

	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health targetHealth = currentTarget.GetComponent<Health> ();
			if (targetHealth) {
				targetHealth.DealDamage (damage);
			}
		}
	}

	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
