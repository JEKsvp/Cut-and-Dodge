using UnityEngine;
using System.Collections;

public class ChosenBlocks : MonoBehaviour {

	private GameObject[] playerBlocks;
	private GameObject[] creatureBlocks;
	private GameObject[] backgroundBlocks;
	private GameObject[] musicBlocks;

	public string status;
	private string tempStatus;

	// Use this for initialization
	void Start () {
		status = "PlayerBlocks";
		tempStatus = status;

		playerBlocks = GameObject.FindGameObjectsWithTag ("PlayerBlock");
		creatureBlocks = GameObject.FindGameObjectsWithTag ("CreatureBlock");
		backgroundBlocks = GameObject.FindGameObjectsWithTag ("BackgroundBlock");
		musicBlocks = GameObject.FindGameObjectsWithTag ("MusicBlock");
	}
	
	// Update is called once per frame
	void Update () {

		if (tempStatus != status) {
			if (status == "PlayerBlocks") {
				StartCoroutine (showPlayerBlocks ());
				switch (tempStatus) {
				case "CreatureBlocks":
					StartCoroutine (hideCreatureBlocks ());
					break;
				case "BackgroundBlocks":
					StartCoroutine (hideBackgroundBlocks ());
					break;
				case "MusicBlocks":
					StartCoroutine (hideMusicBlocks ());
					break;
				}
			}
			if (status == "CreatureBlocks") {
				StartCoroutine (showCreatureBlocks ());
				switch (tempStatus) {
				case "PlayerBlocks":
					StartCoroutine (hidePlayerBlocks ());
					break;
				case "BackgroundBlocks":
					StartCoroutine (hideBackgroundBlocks ());
					break;
				case "MusicBlocks":
					StartCoroutine (hideMusicBlocks ());
					break;
				}
			}
			if (status == "BackgroundBlocks") {
				StartCoroutine (showBackgroundBlocks ());
				switch (tempStatus) {
				case "CreatureBlocks":
					StartCoroutine (hideCreatureBlocks ());
					break;
				case "PlayerBlocks":
					StartCoroutine (hidePlayerBlocks ());
					break;
				case "MusicBlocks":
					StartCoroutine (hideMusicBlocks ());
					break;
				}
			}
			if (status == "MusicBlocks") {
				StartCoroutine (showMusicBlocks ());
				switch (tempStatus) {
				case "CreatureBlocks":
					StartCoroutine (hideCreatureBlocks ());
					break;
				case "BackgroundBlocks":
					StartCoroutine (hideBackgroundBlocks ());
					break;
				case "PlayerBlocks":
					StartCoroutine (hidePlayerBlocks ());
					break;
				}
			}

			tempStatus = status;
		}


	}

	IEnumerator showPlayerBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject playerBlock in playerBlocks) {
				playerBlock.transform.Rotate (new Vector3 (0, 9f, 0));
				playerBlock.GetComponent<Collider2D> ().enabled = true;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator hidePlayerBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject playerBlock in playerBlocks) {
				playerBlock.transform.Rotate (new Vector3 (0, -9f, 0));
				playerBlock.GetComponent<Collider2D> ().enabled = false;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator showCreatureBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject creatureBlock in creatureBlocks) {
				creatureBlock.transform.Rotate (new Vector3 (0, 9f, 0));
				creatureBlock.GetComponent<Collider2D> ().enabled = true;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator hideCreatureBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject creatureBlock in creatureBlocks) {
				creatureBlock.transform.Rotate (new Vector3 (0, -9f, 0));
				creatureBlock.GetComponent<Collider2D> ().enabled = false;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator showBackgroundBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject backgroundBlock in backgroundBlocks) {
				backgroundBlock.transform.Rotate (new Vector3 (0, 9f, 0));
				backgroundBlock.GetComponent<Collider2D> ().enabled = true;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator hideBackgroundBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject backgroundBlock in backgroundBlocks) {
				backgroundBlock.transform.Rotate (new Vector3 (0, -9f, 0));
				backgroundBlock.GetComponent<Collider2D> ().enabled = false;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator showMusicBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject musicBlock in musicBlocks) {
				musicBlock.transform.Rotate (new Vector3 (0, 9f, 0));
				musicBlock.GetComponent<Collider2D> ().enabled = true;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator hideMusicBlocks(){
		for (int i = 0; i < 10; i++) {
			foreach (GameObject musicBlock in musicBlocks) {
				musicBlock.transform.Rotate (new Vector3 (0, -9f, 0));
				musicBlock.GetComponent<Collider2D> ().enabled = false;
			}
			yield return new WaitForSeconds (0.01f);
		}
	}

}
