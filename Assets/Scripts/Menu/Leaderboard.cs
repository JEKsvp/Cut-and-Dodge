using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

	private bool isScoreSent;

	void Start()
	{
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
		if (PlayerPrefs.GetInt("ConnectOption") == 0 || PlayerPrefs.GetInt("ConnectOption") == 1) {
			isScoreSent = false;
			Social.localUser.Authenticate((bool success) =>
			{
				if (success)
					Debug.Log("Successfully logged in");
				else
					Debug.Log("Logging in Error");
			});
		}
	}

	void Update()
	{
		if (GameStatus.gameStatus == "GameOver" && !isScoreSent)
		{
			isScoreSent = true;
			long score = (long) GameObject.Find("Score").GetComponent<ScoreCounter>().score;
			if (score >= 50)
			{
				if (Social.localUser.authenticated)
				{
					Social.ReportScore(score, GPRes2.leaderboard_hight_score, (bool success) =>
					{
						if (success)
						{
							Debug.Log("Score was written");
						}
						else
						{
							Debug.Log("Written failed");
						}
					});
				}
			}
		}
	}


	public void showLeaderBoadrd()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowLeaderboardUI();
		}
		else {
			GameStatus.gameStatus = "InOptions";
		}
	}
}
