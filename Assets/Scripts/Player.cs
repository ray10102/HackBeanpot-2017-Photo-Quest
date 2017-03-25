using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CameraController camera;
    Rigidbody2D rb;
    GameObject walls;

    // Use this for initialization
    void Start() {
        camera = FindObjectOfType<CameraController>();
        rb = GetComponent<Rigidbody2D>();
        walls = GameObject.Find("Walls");
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            pos.y += 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            pos.y -= 1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            pos.x += 1;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            pos.x -= 1;
        }
        bool hasWall = false;
        foreach (Transform wall in walls.transform) {
            if (wall.position == pos) {
                hasWall = true;
            }
        }

        if (!hasWall) {
            transform.position = pos;
            camera.updateCamera();
        }
    }
}
