using UnityEngine;
using System.Collections;

public class ScrollShopMenu : MonoBehaviour {

	public float speed;

	public AudioClip sound;
	private AudioSource audio;

	private Vector2 startPos;
	private RectTransform rec;
	private string tempGameStatus;

	private bool inShop;
	private bool scrollingOut;

	private Vector3 screenSize;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();

		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (width, height));
		gameObject.GetComponent<RectTransform> ().position = new Vector2 (0, screenSize.y*1.56f);

		startPos = rec.anchoredPosition;

		audio = GetComponent<AudioSource>();

		inShop = false;
	}

	void Update(){
		if (GameStatus.gameStatus == "Start") {
			StartCoroutine (destroy ());
		}
		if (GameStatus.gameStatus == "StartMenu") {
			if (inShop == true) {
				if(scrollingOut == false)
					StartCoroutine (scrollOut ());
			}
		}
	}


	void OnMouseUp(){
		if (GameStatus.gameStatus != "InShop") {
			StartCoroutine (scrollIn ());
		} else {
			StartCoroutine (scrollOut ());
		}
	}

	IEnumerator scrollIn(){
		audio.PlayOneShot (sound);
		gameObject.GetComponent<Collider2D> ().enabled = false;
		while (rec.anchoredPosition.y > 0) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, new Vector2(0,0), 40);
			yield return new WaitForSeconds (0.01f);
		}
		GameStatus.gameStatus = "InShop";
		gameObject.GetComponent<Collider2D> ().enabled = true;
		inShop = true;
	}

	IEnumerator scrollOut(){
		scrollingOut = true;
		audio.PlayOneShot (sound);
		gameObject.GetComponent<Collider2D> ().enabled = false;
		while (rec.anchoredPosition.y < startPos.y) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, startPos, 40);
			yield return new WaitForSeconds (0.01f);
		}
		GameStatus.gameStatus = "StartMenu";
		gameObject.GetComponent<Collider2D> ().enabled = true;
		inShop = false;
		scrollingOut = false;
	}

	IEnumerator destroy(){
		while (rec.anchoredPosition.y < startPos.y + 10f) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition,new Vector2(startPos.x, startPos.y + 10f), 40);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}
}
