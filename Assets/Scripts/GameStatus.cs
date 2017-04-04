using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public static string gameStatus;
	private string temp;

	void Start () {
		temp = gameStatus;

		if (PlayerPrefs.GetInt("Restart") == 1)
		{
			GameStatus.gameStatus = "Start";
			PlayerPrefs.SetInt("Restart", 0);
			Destroy(GameObject.Find("ScoreMenu"));
			Destroy(GameObject.Find("ShopMenu"));
			Destroy(GameObject.Find("MainMenu"));
		}
		else {
			gameStatus = "StartMenu";
		}
	}
	
	void Update () {
		if (temp != gameStatus) {
			temp = gameStatus;
		}
	}
}
