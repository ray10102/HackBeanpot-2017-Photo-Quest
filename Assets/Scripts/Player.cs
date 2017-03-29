using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    private CameraController camera;
    private Rigidbody2D rb;
    private IndestructableBarrier[] walls;
    private DestructableBarrier[] barriers;
    private Animator anim;
    private InventoryItem equipped;
    public List<InventoryItem> inventory;
    private bool hasEquipped;
    public float speed;
    

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        camera = FindObjectOfType<CameraController>();
        rb = GetComponent<Rigidbody2D>();
        walls = GameObject.FindObjectsOfType<IndestructableBarrier>();
        barriers = GameObject.FindObjectsOfType<DestructableBarrier>();
        this.hasEquipped = false;
    }

    // Update is called once per frame
    void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector3 pos = transform.position;

        // reset the animator
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("right", false);
        anim.SetBool("left", false);

        // move the player, activate the animator
        if (Input.GetKey(KeyCode.UpArrow)) {
            pos.y += speed * Time.deltaTime;
            anim.SetBool("up", true);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            pos.y -= speed * Time.deltaTime;
            anim.SetBool("down", true);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            pos.x += speed * Time.deltaTime;
            anim.SetBool("right", true);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            pos.x -= speed * Time.deltaTime;
            anim.SetBool("left", true);
        }

        // is there a wall in the way?
        bool hasWall = false;
        foreach (IndestructableBarrier ib in walls) {
            if (ib) {
                bool inWall = pos.x >= ib.offsetLeft && pos.x <= ib.right && pos.y <= ib.top && pos.y >= ib.offsetBottom;
                if (inWall) {
                    hasWall = true;
                    break;
                }
            }
        }

        // if theres no wall in the way, is there a barrier?
        if (!hasWall) {
            foreach (DestructableBarrier db in barriers) {
                if (db.isActive) {
                    bool inBarrier = pos.x >= db.offsetLeft && pos.x <= db.right && pos.y <= db.top && pos.y >= db.offsetBottom;
                    if (inBarrier) {
                        hasWall = true;
                        break;
                    }
                }
            }
        }

        // update camera if no wall in the way
        if (!hasWall) {
            transform.position = pos;
            camera.updateCamera();
        }
    }

    public bool isEquipped()
    {
        return this.hasEquipped;
    }

    public void wasItemEffective(DestructableItemPackage destructableObjectPackage)
    {
      
        GameObject toBeDestroyed = destructableObjectPackage.destructableItem;
        InventoryItem vuln = destructableObjectPackage.item;

        if (this.equipped.itemEquals(vuln))
        {
            GameObject.Destroy(toBeDestroyed);
            this.hasEquipped = false;
            this.equipped = null;
        }
        else
        {

        }



    }

    public void equipItem(InventoryItem itemToEquip)
    {
        this.equipped = itemToEquip;
        this.hasEquipped = true;
    }

    //Returns players currently equipped game object.
    public InventoryItem currentlyEquipped()
    {
        return this.equipped;
    }

    public void addItem(InventoryItem item)
    {
        this.inventory.Add(item);
    }
}