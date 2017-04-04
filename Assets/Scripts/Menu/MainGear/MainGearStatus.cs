using UnityEngine;
using System.Collections;

public class MainGearStatus : MonoBehaviour {

	public static string status;
	private string tempStatus;

	void Start () {
		status = "Play";
	}

	void Update () {
	
		if (tempStatus != status) {
			switch (status) {
			case "Play":
				transform.Find ("play").GetComponent<Collider2D> ().enabled = true;
				transform.Find ("options").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("share").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("leaderboard").GetComponent<Collider2D> ().enabled = false;
				break;
			case "Options":
				transform.Find ("play").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("options").GetComponent<Collider2D> ().enabled = true;
				transform.Find ("share").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("leaderboard").GetComponent<Collider2D> ().enabled = false;
				break;
			case "Share":
				transform.Find ("play").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("options").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("share").GetComponent<Collider2D> ().enabled = true;
				transform.Find ("leaderboard").GetComponent<Collider2D> ().enabled = false;
				break;
			case "Leaderboard":
				transform.Find ("play").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("options").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("share").GetComponent<Collider2D> ().enabled = false;
				transform.Find ("leaderboard").GetComponent<Collider2D> ().enabled = true;
				break;

			}
			tempStatus = status;
		}
	}
}
