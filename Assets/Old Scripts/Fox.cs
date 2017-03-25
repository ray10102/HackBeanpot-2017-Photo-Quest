﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
	

	void OnTriggerEnter2D (Collider2D col) {
		GameObject obj = col.gameObject;

		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("Jump Trigger");
		} else {
			attacker.Attack (obj);
			anim.SetBool ("isAttacking", true);
		}
	}
}
