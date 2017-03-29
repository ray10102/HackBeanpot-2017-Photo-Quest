using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBarrier : MonoBehaviour {

    public int key;
    public InventoryItem vulnerableAgainst;
    public bool isActive;
    public float top, left, right, bottom;

    // see IndestructableBarrier.cs for info on fields
    public float bottomOffset;
    public float offsetLeft {
        get { return left - 1; }
    }
    public float offsetBottom {
        get { return bottom - bottomOffset; }
    }

    private GameObject player;
    private Camera myCamera;
    private AudioSource audio;

    void Start() {
        isActive = true;
        myCamera = GameObject.FindObjectOfType<Camera>();
        audio = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>().gameObject;
    }

    //Check if what the player has equipped is what this is vulnerable against.
    void OnMouseDown() {
        DestructableItemPackage package = new DestructableItemPackage(vulnerableAgainst, gameObject);

        player.SendMessage("wasItemEffective", package);

        /**
        //if (Inventory.isSelected) {
            Debug.Log("Mouse clicked: " + Input.mousePosition.x + ", " + Input.mousePosition.y);
            Vector2 blockPos = WorldPointGridSnap();
            Vector3 v3 = new Vector3(blockPos.x, blockPos.y);
            /*foreach (Transform child in objectsParent.transform) {
                if (child.position == v3) {
                    Debug.Log(gameObject + " clicked");
                }
            }*/

       // }
    }

    public void SetVulnerableAgainst(InventoryItem vulnerableAgainst)
    {
        this.vulnerableAgainst = vulnerableAgainst;
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

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(left, top));
        Gizmos.DrawLine(new Vector3(right, bottom), new Vector3(right, top));
        Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(right, bottom));
        Gizmos.DrawLine(new Vector3(left, top), new Vector3(right, top));
    }
}