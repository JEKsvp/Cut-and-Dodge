using UnityEngine;
using System.Collections;

public class RotateMenu : MonoBehaviour {

	public string direction;

	AudioSource audio;

	private bool rotating;
	private string[] status;
	public static int statusID;

	private GameObject menu;
	private GameObject gear1;
	private GameObject gear2;
	private GameObject gear3;
	private GameObject gear4;

	void Start(){
		statusID = 0;
		rotating = false;
		status = new string[] {"Play", "Options", "Leaderboard","Share"};

		menu = GameObject.Find ("MainMenu");
		gear1 = GameObject.Find ("gear1");
		gear2 = GameObject.Find ("gear2");
		gear3 = GameObject.Find ("gear3");
		gear4 = GameObject.Find ("gear4");

		audio = GetComponent<AudioSource>();
	}

	void Update() {
		if (GameStatus.gameStatus == "Start") {
			Destroy(gameObject);
		}
	}

	void OnMouseUp(){
		if (!rotating) {
			StartCoroutine (Rotate (menu, direction, 2));

			if (direction == "right") {
				StartCoroutine (Rotate (gear1, "left", 6f));
				StartCoroutine (Rotate (gear2, "right", 4f));
				StartCoroutine (Rotate (gear3, "left", 4f));
				StartCoroutine (Rotate (gear4, "right", 4f));
			}
			if (direction == "left") {
				StartCoroutine (Rotate (gear1, "right", 6f));
				StartCoroutine (Rotate (gear2, "left", 4f));
				StartCoroutine (Rotate (gear3, "right", 4f));
				StartCoroutine (Rotate (gear4, "left", 4f));
			}
		}
	}



	IEnumerator Rotate(GameObject obj, string dir, float speed){
		rotating = true;
		audio.Play ();
		float tempDir = 0;
	
		if (dir == "right") {
			if (statusID == 3) {
				statusID = 0;
			} else {
				statusID += 1;
			}
			MainGearStatus.status = status [statusID];
			tempDir = -speed;
		}
		if (dir == "left") {
			if (statusID == 0) {
				statusID = 3;
			} else {
				statusID -= 1;
			}
			MainGearStatus.status = status [statusID];
			tempDir = speed;
		}

		for (int i = 0; i < 45; i++) {
			obj.transform.Rotate (new Vector3 (0, 0, tempDir));
			yield return new WaitForSeconds (0.01f);
		}
		rotating = false;
	}
}
