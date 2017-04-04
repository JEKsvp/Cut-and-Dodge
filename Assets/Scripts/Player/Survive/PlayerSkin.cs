using UnityEngine;
using System.Collections;

public class PlayerSkin : MonoBehaviour {

	public int skinId;
	private int tempSkinId;
	private Vector3 playerPosition;
	private GameObject player;




	void Start () {
		changeSkin ();
		tempSkinId = skinId;

		playerPosition = GameObject.Find("Player").transform.position;
	}
		
	void Update () {
		if (tempSkinId != skinId) {
			changeSkin ();
			tempSkinId = skinId;
		}

	}

	void changeSkin(){
		switch (skinId) {
			case 0:
				Destroy(GameObject.Find("Player"));
				player = Instantiate(Resources.Load("Prefabs/Player0")) as GameObject;
				player.name = "Player";
				player.transform.position = playerPosition;
				if (SoundCheck.isChecked == true) 
					player.GetComponent<AudioSource>().mute = false;
				else
					player.GetComponent<AudioSource>().mute = true;
				break;
			case 1:
				Destroy(GameObject.Find("Player"));
				player = Instantiate(Resources.Load("Prefabs/Player1")) as GameObject;
				player.name = "Player";
				player.transform.position = playerPosition;
				if (SoundCheck.isChecked == true)
					player.GetComponent<AudioSource>().mute = false;
				else
					player.GetComponent<AudioSource>().mute = true;
				break;
			case 2:
				Destroy(GameObject.Find("Player"));
				player = Instantiate(Resources.Load("Prefabs/Player2")) as GameObject;
				player.name = "Player";
				player.transform.position = playerPosition;
				if (SoundCheck.isChecked == true)
					player.GetComponent<AudioSource>().mute = false;
				else
					player.GetComponent<AudioSource>().mute = true;
				break;
		}
	}
}
