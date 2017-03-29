using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float bottom, top, left, right;
    Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void updateCamera() {
        Vector3 pos = transform.position;
        Vector3 playerPos = player.gameObject.transform.position;
        if (left <= playerPos.x && playerPos.x <= right) {
            pos.x = playerPos.x + .5f;
        }
        if (playerPos.y >= bottom + 2 && playerPos.y <= top - 2) {
            pos.y = playerPos.y - 1f;
        }
        pos.z = -30;
        transform.position = pos;
    }
}
