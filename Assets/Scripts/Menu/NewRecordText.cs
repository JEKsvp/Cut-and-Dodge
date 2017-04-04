using UnityEngine;
using System.Collections;

public class NewRecordText : MonoBehaviour {

	private float tempScore;
	private bool isCourStarted;


	void Start () {
		isCourStarted = false;

		tempScore = (float)System.Math.Round (SPlayerPrefs.GetFloat ("Score"));
	}


	void Update () {
		if (GameStatus.gameStatus == "GameOver" && tempScore < (float)System.Math.Round (SPlayerPrefs.GetFloat ("Score"))) {
			if (!isCourStarted) {
				StartCoroutine (showText ());
			}
		}
	}
		

	IEnumerator showText (){
		isCourStarted = true;
		for (int i = 0; i < 50; i++){
			gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0f);
			yield return new WaitForSeconds(0.01f);
		}
	}
}
