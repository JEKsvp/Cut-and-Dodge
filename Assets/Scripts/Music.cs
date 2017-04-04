using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	private AudioSource audio;

	private bool isPlaying;

	void Start () {
		audio = GetComponent<AudioSource>();

		isPlaying = false;
	}


	void Update () {
		if (GameStatus.gameStatus == "Playing" && !isPlaying) {
			playMusic ();
		}
		if (GameStatus.gameStatus == "GameOver") {
			stopMusic ();
		}

	}
		
	void playMusic(){
		isPlaying = true;
		audio.Play ();
	}

	void stopMusic(){
		isPlaying = true;
		audio.Stop ();
	}
}
