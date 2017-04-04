using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	private AudioSource audio;

	private bool isPlaying;

	void Start()
	{
		audio = GetComponent<AudioSource>();

		isPlaying = false;
	}


	void Update()
	{
		if ((GameStatus.gameStatus == "StartMenu" || GameStatus.gameStatus == "Start") && !isPlaying)
		{
			playMusic();
		}
		if (GameStatus.gameStatus == "Playing")
		{
			stopMusic();
		}

	}

	void playMusic()
	{
		isPlaying = true;
		audio.Play();
	}

	void stopMusic()
	{
		isPlaying = true;
		audio.Stop();
	}
}
