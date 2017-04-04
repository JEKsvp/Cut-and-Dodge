using UnityEngine;
using System.Collections;

public class CloseCredits : MonoBehaviour {

	void Update()
	{
		if (GameStatus.gameStatus == "InCredits")
		{
			gameObject.GetComponent<Collider2D>().enabled = true;
		}
		if (GameStatus.gameStatus != "InCredits")
		{
			gameObject.GetComponent<Collider2D>().enabled = false;
		}
		if (GameStatus.gameStatus == "Start")
		{
			Destroy(gameObject);
		}
	}

	void OnMouseUp()
	{
		GameStatus.gameStatus = "StartMenu";
	}
}
