using UnityEngine;
using System.Collections;

public class GameOverSound : MonoBehaviour {

	private AudioSource audio;
	private bool played;


	void Start () {
		played = false;
		audio = GetComponent<AudioSource>();
	}
	

	void Update () {
		if (!played) {
			if (GameStatus.gameStatus == "GameOver") {
				audio.Play();
				played = true;
			}
		}
	}
}
