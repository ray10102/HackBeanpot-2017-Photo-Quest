using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructableBarrier : MonoBehaviour {

    // the left, right, top, and bottom boundaries of the wall
    public float right, left, top, bottom;
    // Amount to offset the bottom by
    public float bottomOffset;

    // The actual left and bottom bounds
    public float offsetLeft {
        get { return left - 1; }
    }
    public float offsetBottom {
        get { return bottom - bottomOffset; }
    }


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(left, top));
        Gizmos.DrawLine(new Vector3(right, bottom), new Vector3(right, top));
        Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(right, bottom));
        Gizmos.DrawLine(new Vector3(left, top), new Vector3(right, top));
    }
}
