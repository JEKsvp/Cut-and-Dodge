using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewCoinInGame : MonoBehaviour {

	private int tempCoins;

	void Start () {
	 tempCoins = PlayerPrefs.GetInt("Coins");
		gameObject.GetComponent<Text>().text = (int)PlayerPrefs.GetInt("Coins") + "";
	}
	
	void Update () {
		if (tempCoins != PlayerPrefs.GetInt("Coins")) {
			StartCoroutine(changeView());
			tempCoins = PlayerPrefs.GetInt("Coins");
		}
	}

	IEnumerator changeView() {
		yield return new WaitForSeconds(0.3f);
		gameObject.GetComponent<Text>().text = (int)PlayerPrefs.GetInt("Coins") + "";
	}
}
