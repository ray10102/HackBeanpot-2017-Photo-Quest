using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars;

	public enum Status {SUCCESS, FAILURE};

	void Start () {
		stars = 150;
		starText = GetComponent<Text> ();
		starText.text = stars.ToString ();
	}

	public void AddStars (int addStars) {
		stars += addStars;
		starText.text = stars.ToString ();
	}

	public Status UseStars (int useStars) {
		if (stars >= useStars) {
			stars -= useStars;
			starText.text = stars.ToString ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
}
