using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

	void OnMouseUp()
	{
		GameStatus.gameStatus = "InCredits";
	}
}
