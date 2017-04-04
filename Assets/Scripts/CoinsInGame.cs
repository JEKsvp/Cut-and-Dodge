using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsInGame : MonoBehaviour {


	public GameObject coin;
	public GameObject goldGear;

	public IEnumerator showCoins() {
		goldGear.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		coin.GetComponent<Text>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 1f);
		yield return new WaitForSeconds(2f);
		for (int i = 0; i < 20; i++) {
			goldGear.GetComponent<Image>().color -= new Color(0, 0, 0, 0.05f);
			coin.GetComponent<Text>().color -= new Color(0, 0, 0, 0.05f);
			yield return new WaitForSeconds(0.01f);
		}
	}
}
