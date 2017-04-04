using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicCheck : MonoBehaviour {

	private GameObject gameMusic;
	private GameObject menuMusic;

	public bool isChecked;


	void Start () {
		gameMusic = GameObject.Find ("GameMusic");
		menuMusic = GameObject.Find("MenuMusic");
		if (PlayerPrefs.GetInt ("MusicStatus") == 0) {
			activate ();
		}
		if (PlayerPrefs.GetInt ("MusicStatus") == 1) {
			activate ();
		} else {
			if (PlayerPrefs.GetInt ("MusicStatus") == 2) {
				deactivate ();
			}
		}
	}
	
	void OnMouseUp(){
		if (isChecked) {
			deactivate ();
		} else {
			activate ();
		}
	}

	void activate(){
		gameObject.GetComponent<Image> ().enabled = true;
		gameMusic.GetComponent<AudioSource> ().mute = false;
		menuMusic.GetComponent<AudioSource>().mute = false;
		isChecked = true;
		PlayerPrefs.SetInt ("MusicStatus", 1);
		PlayerPrefs.Save();
	}

	void deactivate(){
		gameObject.GetComponent<Image> ().enabled = false;
		gameMusic.GetComponent<AudioSource> ().mute = true;
		menuMusic.GetComponent<AudioSource>().mute = true;
		isChecked = false;
		PlayerPrefs.SetInt ("MusicStatus", 2);
		PlayerPrefs.Save();
	}
}
