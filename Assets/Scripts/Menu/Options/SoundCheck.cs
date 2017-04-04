using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundCheck : MonoBehaviour {

	private AudioSource[] soundsGM;
	public static bool isChecked;


	void Start () {
		soundsGM = GameObject.FindObjectsOfTypeAll (typeof(AudioSource))as AudioSource[];
		if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
			activate ();
		}
		if (PlayerPrefs.GetInt ("SoundStatus") == 1) {
			activate ();
		} else {
			if (PlayerPrefs.GetInt ("SoundStatus") == 2) {
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
		soundsGM = GameObject.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
		gameObject.GetComponent<Image> ().enabled = true;
		bool muteGameMusic = GameObject.Find ("GameMusic").GetComponent<AudioSource> ().mute;
		bool muteMenuMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>().mute;
		foreach (AudioSource sound in soundsGM) {
			sound.mute = false;
		}
		GameObject.Find ("GameMusic").GetComponent<AudioSource> ().mute = muteGameMusic;
		GameObject.Find("MenuMusic").GetComponent<AudioSource>().mute = muteMenuMusic;
		isChecked = true;
		PlayerPrefs.SetInt ("SoundStatus", 1);
		PlayerPrefs.Save();
	}

	void deactivate(){
		soundsGM = GameObject.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
		bool muteGameMusic = GameObject.Find ("GameMusic").GetComponent<AudioSource> ().mute;
		bool muteMenuMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>().mute;
		gameObject.GetComponent<Image> ().enabled = false;
		foreach (AudioSource sound in soundsGM) {
			sound.mute = true;
		}
		GameObject.Find ("GameMusic").GetComponent<AudioSource> ().mute = muteGameMusic;
		GameObject.Find("MenuMusic").GetComponent<AudioSource>().mute = muteMenuMusic;
		isChecked = false;
		PlayerPrefs.SetInt ("SoundStatus", 2);
		PlayerPrefs.Save();
	}
}
