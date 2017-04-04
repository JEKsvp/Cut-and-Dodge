using UnityEngine;
using System.Collections;

public class CloseShop : MonoBehaviour {

	private bool closing;

	void Start() {
		closing = false;
	}

	void Update(){
		if (GameStatus.gameStatus == "InShop") {
			gameObject.GetComponent<Collider2D> ().enabled = true;
		}
		if (GameStatus.gameStatus != "InShop") {
			if(!closing)
			StartCoroutine(close());
		}
		if (GameStatus.gameStatus == "Start")
		{
			Destroy(gameObject);
		}
	}

	void OnMouseUp(){
		GameStatus.gameStatus = "StartMenu";
	}

	IEnumerator close() {
		closing = true;
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Collider2D>().enabled = false;
		closing = false;
	}
}
