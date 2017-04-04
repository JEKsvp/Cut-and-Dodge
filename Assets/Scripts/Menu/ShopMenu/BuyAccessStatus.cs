using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyAccessStatus : MonoBehaviour {

	public static bool show;
	private bool opening, closing, isOpen;
	private GameObject buyBlock;
	private GameObject buyBlock1;
	public Sprite[] enemySkins;
	public Sprite[] backgrounds;
	public Sprite[] players;

	void Start () {
		show = false;
		buyBlock = GameObject.Find ("BuyAccessBlock");
		buyBlock1 = GameObject.Find ("BuyAccessBlock1");
		buyBlock.GetComponent<Collider2D> ().enabled = false;
		buyBlock1.GetComponent<Collider2D> ().enabled = false;
	}

	void Update () {
		if (GameStatus.gameStatus == "Start") {
			Destroy (gameObject);
		}
		if (show) {
			if (!opening) {
				if(!isOpen)
				StartCoroutine (openBuyAccess ());
			}
		} else {
			if (!closing) {
				if(isOpen)
				StartCoroutine (closeBuyAccess ());
			}
		}
	}

	IEnumerator openBuyAccess(){
		GameObject.Find("ScoreMenu").GetComponent<Collider2D>().enabled = false;
		buyBlock.GetComponent<Collider2D> ().enabled = true;
		buyBlock1.GetComponent<Collider2D> ().enabled = true;
		opening = true;
		isOpen = true;
		switch (Price.contentType) {
			case "Creature":
				transform.Find("BASkin").GetComponent<Image>().overrideSprite = enemySkins[Price.contentID];
				break;
			case "Player":
				transform.Find("BASkin").GetComponent<Image>().overrideSprite = players[Price.contentID];
				break;
			case "Background":
				transform.Find("BASkin").GetComponent<Image>().overrideSprite = backgrounds[Price.contentID];
				break;
			case "Music":
				break;
		}
		GameObject buyAccess = GameObject.Find ("BuyAccess");
		for (int i = 0; i < 20; i++) {
			buyAccess.transform.localScale += new Vector3 (0f, 0.05f, 0f);
			yield return new WaitForSeconds (0.01f);
		}
		opening = false;
	}

	IEnumerator closeBuyAccess(){
		closing = true;
		isOpen = false;
		GameObject buyAccess = GameObject.Find ("BuyAccess");
		for (int i = 0; i < 20; i++) {
			buyAccess.transform.localScale -= new Vector3 (0f, 0.05f, 0f);
			yield return new WaitForSeconds (0.01f);
		}
		closing = false;
		buyBlock.GetComponent<Collider2D> ().enabled = false;
		buyBlock1.GetComponent<Collider2D> ().enabled = false;
		GameObject.Find("ScoreMenu").GetComponent<Collider2D>().enabled = true;
	}
}
