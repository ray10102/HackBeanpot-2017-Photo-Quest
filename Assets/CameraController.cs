using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

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
        if (0 <= playerPos.x && playerPos.x <= 30) {
            pos.x = playerPos.x;
        }
        if (playerPos.y >= -15 && playerPos.y <= 15) {
            pos.y = playerPos.y - 1.5f;
        }
        pos.z = -10;
        transform.position = pos;
    }
}
