using UnityEngine;
using System.Collections;

public class NumberOfStarts : MonoBehaviour {

	private string gameOverStatus;
	private string tempGameOverStatus;

	private string startStatus;
	private string tempStartStatus;

	public GameObject rate;
	public GameObject learning;

	void Start () {
		gameOverStatus = "GameOver";
		tempGameOverStatus = "";

		startStatus = "Start";
		tempStartStatus = "";
	}
	
	void Update () {

		if (GameStatus.gameStatus == gameOverStatus && tempGameOverStatus != gameOverStatus) {
			PlayerPrefs.SetInt("GameOvers", PlayerPrefs.GetInt("GameOvers") + 1);
			tempGameOverStatus = gameOverStatus;
			if (PlayerPrefs.GetInt("GameOvers") == 20)
			{
				rate.SetActive(true);
			}

		}


		if (GameStatus.gameStatus == startStatus && tempStartStatus != startStatus)
		{
			if (PlayerPrefs.GetInt("Starts") == 0)
			{
				learning.SetActive(true);
			}
			PlayerPrefs.SetInt("Starts", PlayerPrefs.GetInt("Starts") + 1);
			tempStartStatus = startStatus;
			
		}
	}
}
