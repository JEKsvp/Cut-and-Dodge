using UnityEngine;
using System.Collections;

public class SelectedBackground : MonoBehaviour {

	public int backgroundID;
	private int tempBackgroundID;

	public GameObject[] backgrounds;

	void Start () {

		changeBackground ();
		tempBackgroundID = backgroundID;

	}

	void Update () {
	
		if (tempBackgroundID != backgroundID) {
			changeBackground ();
			tempBackgroundID = backgroundID;
		}
	}

	void changeBackground(){
		foreach (GameObject background in backgrounds) {
			background.SetActive (false);
		}

		backgrounds [backgroundID].SetActive (true);
	}
}
