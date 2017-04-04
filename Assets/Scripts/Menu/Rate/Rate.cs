using UnityEngine;
using System.Collections;

public class Rate : MonoBehaviour {

	public GameObject restartButton;
	public GameObject shareButton;
	public GameObject homeButton;

	

	void OnEnable() {
		restartButton.GetComponent<Collider2D>().enabled = false;
		shareButton.GetComponent<Collider2D>().enabled = false;
		homeButton.GetComponent<Collider2D>().enabled = false;
	}

	void OnDisable() {
		restartButton.GetComponent<Collider2D>().enabled = true;
		shareButton.GetComponent<Collider2D>().enabled = true;
		homeButton.GetComponent<Collider2D>().enabled = true;
	}
}
