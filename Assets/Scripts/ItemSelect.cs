using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour {

    private Camera myCamera;
    private Player player;

    void Start() {
        player = GameObject.FindObjectOfType<Player>();
        myCamera = GameObject.FindObjectOfType<Camera>();
    }

    void OnMouseDown() {
        Vector2 placePos = WorldPointGridSnap();
        if (placePos.x != 0) {
            if (placePos.y != 0) {
                Debug.Log("move up");
            }
        }
    }

    Vector2 WorldPointGridSnap() {
        Vector2 worldPos = CalculateMouseClickWorldPoint();
        float worldX = worldPos.x;
        float worldY = worldPos.y;
        worldX = Mathf.Round(worldX);
        worldY = Mathf.Round(worldY);
        Vector2 newWorldPos = new Vector2(worldX, worldY);

        return newWorldPos;
    }

    Vector2 CalculateMouseClickWorldPoint() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 thisweirdthing = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(thisweirdthing);

        return worldPos;
    }
}
