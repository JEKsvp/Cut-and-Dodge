using UnityEngine;
using System.Collections;

public class CloseScore : MonoBehaviour {

	void Update(){
		if (GameStatus.gameStatus == "InScore") {
			gameObject.GetComponent<Collider2D> ().enabled = true;
		}
		if (GameStatus.gameStatus != "InScore") {
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
		if (GameStatus.gameStatus == "Start")
		{
			Destroy(gameObject);
		}
	}

	void OnMouseUp(){
		GameStatus.gameStatus = "StartMenu";
	}
}
