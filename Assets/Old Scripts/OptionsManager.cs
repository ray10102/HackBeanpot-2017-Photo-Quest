using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider VolumeSlider;
	public Slider DifficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;


	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		VolumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		DifficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (VolumeSlider.value);
	}

	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume (VolumeSlider.value);
		PlayerPrefsManager.SetDifficulty (DifficultySlider.value);
		levelManager.LoadLevel ("01a Start Menu");
	}

	public void SetDefaults () {
		VolumeSlider.value = .5f;
		DifficultySlider.value = 2f;
	}
}
