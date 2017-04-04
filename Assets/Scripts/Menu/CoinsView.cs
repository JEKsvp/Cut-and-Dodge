using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsView : MonoBehaviour {

	void Update () {
		gameObject.GetComponent<Text> ().text = (int) PlayerPrefs.GetInt ("Coins") + "";
	}

}
