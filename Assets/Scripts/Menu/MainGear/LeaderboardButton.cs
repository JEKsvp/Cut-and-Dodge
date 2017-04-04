using UnityEngine;
using System.Collections;

public class LeaderboardButton : MonoBehaviour {

	public GameObject leaderboard;

	void Start () {
	}

	void OnMouseUp()
	{
		leaderboard.GetComponent<Leaderboard>().showLeaderBoadrd();
	}
}
