using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypewriterEffect : MonoBehaviour {
	private Text txt;
    public string line;
    public string[] stories;

    private string story;

    void Awake() {
        txt = GetComponent<Text>();
        txt.text = "";
        if (stories.GetLength(0) <= 0) {
            story = line;
        } else {
            story = stories[Random.Range(0, stories.GetLength(0))];
        }
        // TODO: add optional delay when to start
        StartCoroutine("PlayText");

    }

    IEnumerator PlayText() {
        foreach (char c in story) {
             txt.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        Invoke("DisableText", 2f);
    }

    public void DisableText() {
        gameObject.SetActive(false);
    }

}