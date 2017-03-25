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
            pos.x = playerPos.x;
        }
        if (playerPos.y >= bottom && playerPos.y <= top + 2.85) {
            pos.y = playerPos.y - 1.85f;
        }
        pos.z = -10;
        transform.position = pos;
    }
}
