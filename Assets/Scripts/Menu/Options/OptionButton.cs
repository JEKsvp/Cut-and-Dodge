using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour {

	void OnMouseUp(){
		GameStatus.gameStatus = "InOptions";
	}
}
