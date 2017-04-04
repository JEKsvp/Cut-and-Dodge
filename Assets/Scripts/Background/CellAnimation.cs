using UnityEngine;
using System.Collections;

public class CellAnimation : MonoBehaviour {

	private bool isRunning;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Tail" || col.gameObject.tag == "EnemyHead" && !isRunning) {
			StartCoroutine (Rotate());
		}
	}

	IEnumerator Rotate(){
		isRunning = true;
		for (int i = 0; i < 20; i++) {
			gameObject.transform.Rotate (new Vector3 (9f, 0, 0));
			yield return new WaitForSeconds (0.01f);
		}
		gameObject.transform.Rotate (new Vector3 (180, 0, 0));
		isRunning = false;
	}
}
