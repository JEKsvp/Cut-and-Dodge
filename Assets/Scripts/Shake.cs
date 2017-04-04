using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

	public static bool shakingCamera;
	private bool shakePlayed;

	void Start () {
		shakingCamera = false;
		shakePlayed = false;
	}
	
	void Update () {
		if (GameStatus.gameStatus == "GameOver" && !shakePlayed) {
			StartCoroutine(shakeCamera());
			shakePlayed = true;
		}
	}

	public IEnumerator shakeCamera()
	{
		shakingCamera = true;
		for (int i = 0; i < 1; i++)
		{
			Camera.main.transform.position += new Vector3(0.1f, 0.1f, 0);
			yield return new WaitForSeconds(0.03f);
			Camera.main.transform.position -= new Vector3(0.1f, 0.1f, 0);
			yield return new WaitForSeconds(0.03f);
			Camera.main.transform.position += new Vector3(-0.1f, 0.1f, 0);
			yield return new WaitForSeconds(0.03f);
			Camera.main.transform.position -= new Vector3(-0.1f, 0.1f, 0);
			yield return new WaitForSeconds(0.03f);
		}
		shakingCamera = false;
	}
}
