using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

    public bool treesAreBurning;
    public bool fireAudioIsPlaying;

    private BoxCollider2D col;
    private Tree[] trees;

    // Use this for initialization
    void Start() {
        fireAudioIsPlaying = false;
        treesAreBurning = false;
        col = GetComponent<BoxCollider2D>();
        trees = new Tree[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            trees[i] = transform.GetChild(i).GetComponent<Tree>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !treesAreBurning) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Physics2D.OverlapPoint(mousePosition) == col) {
                Tree closest = null;
                float closestDist = 0f;
                Debug.Log(trees[0]);
                foreach (Tree tree in trees) {
                    Debug.Log("tree being processed is: " + tree);
                    Vector3 thisPos = treeCenter(tree.gameObject.transform.position);
                    float dist = Dist(thisPos, mousePosition);
                    if (closest == null) {
                        closest = tree;
                        closestDist = dist;
                        Debug.Log(closest + ", " + dist);
                    } else if (dist < closestDist) {
                        closest = tree;
                        closestDist = dist;
                        Debug.Log(closest + ", " + dist);
                    }
                }

                closest.isBurning = true;
                treesAreBurning = true;
            }
        }
    }

    private Vector3 treeCenter(Vector3 oldPos) {
        return new Vector3(oldPos.x + 1, oldPos.y + 1, oldPos.z);
    }

    public Tree nearestAdjacentTree(Tree thisTree) {
        Vector3 thisPos = thisTree.gameObject.transform.position;
        thisPos = treeCenter(thisPos);
        Tree closest = null;
        float closestDist = 1000f;
        foreach (Tree tree in trees) {
            if (!tree.isBurning && !tree.markedForBurning) {
                Vector3 thatPos = tree.gameObject.transform.position;
                thatPos = treeCenter(thatPos);
                float dist = Dist(thatPos, thisPos);
                if (dist < 3 && dist < closestDist) {
                    closest = tree;
                    closestDist = dist;
                    if (closestDist == 2) {
                        return closest;
                    }
                }
            }
        }
        return closest;
    }

    public Tree adjacentTree(Tree thisTree) {
        Vector3 thisPos = thisTree.gameObject.transform.position;
        foreach (Tree tree in trees) {
            if (!tree.isBurning && !tree.markedForBurning) {
                float dist = Dist(tree.gameObject.transform.position, thisPos);
                if (dist <= 2) {
                    return tree;
                }
            }
        }
        return null;
    }

    float Dist(Vector3 pt1, Vector3 pt2) {
        return Mathf.Sqrt(Mathf.Pow(pt1.x - pt2.x, 2) + Mathf.Pow(pt1.y - pt2.y, 2));
    }

    float Dist(Vector3 pt1, Vector2 pt2) {
        return Mathf.Sqrt(Mathf.Pow(pt1.x - pt2.x, 2) + Mathf.Pow(pt1.y - pt2.y, 2));
    }

    


}
