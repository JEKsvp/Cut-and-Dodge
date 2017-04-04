using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	void Update() {
		if (GameStatus.gameStatus == "GameOver") {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1);
			PlayerPrefs.Save();
			Destroy (gameObject);
		}
	}
}
