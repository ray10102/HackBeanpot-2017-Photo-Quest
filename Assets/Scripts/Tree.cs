using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    public GameObject firePrefab;
    // Is this tree burning? 
    public bool isBurning;
    // Has this tree already been set on fire?
    public bool hasBeenSet;
    // Has burning already been invoked on this tree?
    public bool markedForBurning;
    // Will this tree be automatically destroyed after burning for a set amount of time?
    public bool doDestroy;
    // how many seconds should there be between each fire spread?
    public float spreadTime;


    // public bool fireIsPlaying;
    // public AudioSource fireSource;

    private TreeManager tm;
    // first closest tree to this one
    private Tree closest1;
    // second closest tree to this one
    private Tree closest2;

	// Use this for initialization
	void Start () {
        tm = transform.parent.GetComponent<TreeManager>();
        if (!tm) {
            Debug.LogError("No TreeManager found");
        }
        isBurning = false;
        hasBeenSet = false;
		// fireIsPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isBurning && !hasBeenSet) {
            Invoke("setFire", .5f);
            hasBeenSet = true;

            closest1 = tm.nearestAdjacentTree(this);
            if (closest1) {
                closest1.markedForBurning= true;
                Invoke("igniteClosest1", spreadTime);
            }

            closest2 = tm.nearestAdjacentTree(this);
            if (closest2) {
                closest2.markedForBurning = true;
                Invoke("igniteClosest2", spreadTime);
            }
        }
	}

    public void igniteClosest1() {
        Debug.Log("closest 1: " + closest1);
        closest1.isBurning = true;
    }

    public void igniteClosest2() {
        closest2.isBurning = true;
        Debug.Log("closest 2: " + closest2);
    }

    public void setFire() {
        Vector3 newPos = new Vector3(transform.position.x + Random.RandomRange(.6f, .85f),
            transform.position.y + Random.RandomRange(.8f, 1.1f), transform.position.z);
        GameObject fire = Instantiate(firePrefab, newPos, Quaternion.identity) as GameObject;
        fire.transform.position = newPos;
        if (doDestroy) {
            Invoke("Destroy", 2f);
        }
        Invoke("setFire1", .25f);
		if (!tm.fireAudioIsPlaying)
		{
            AudioSource audio = tm.GetComponent<AudioSource>();
            if (audio) {
                audio.Play();
                tm.fireAudioIsPlaying = true;
            }
		}
    }

    public void setFire1() {
        Vector3 newPos = new Vector3(transform.position.x + Random.Range(.75f, 1.2f),
            transform.position.y + Random.Range(1.4f, 1.6f), transform.position.z);
        GameObject fire = Instantiate(firePrefab, newPos, Quaternion.identity) as GameObject;
        fire.transform.position = newPos;
        Invoke("setFire2", .5f);

    }

    public void setFire2() {
        Vector3 newPos = new Vector3(transform.position.x + Random.Range(1.8f, 2.1f),
            transform.position.y + Random.Range(.8f, 1.3f), transform.position.z);
        GameObject fire = Instantiate(firePrefab, newPos, Quaternion.identity) as GameObject;
        fire.transform.position = newPos;
    }



    public void Destroy() {
        GameObject.Destroy(gameObject);
    }
}
