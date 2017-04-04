using UnityEngine;
using System.Collections;

public class CloseOptions : MonoBehaviour {

	void Update(){
		if (GameStatus.gameStatus == "InOptions") {
			gameObject.GetComponent<Collider2D> ().enabled = true;
		}
		if (GameStatus.gameStatus != "InOptions") {
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
