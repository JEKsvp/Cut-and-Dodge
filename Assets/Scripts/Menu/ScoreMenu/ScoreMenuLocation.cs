using UnityEngine;
using System.Collections;

public class ScoreMenuLocation : MonoBehaviour {

	public float speed;

	public AudioClip sound;
	private AudioSource audio;

	private Vector2 startPos;
	private RectTransform rec;
	private string tempGameStatus;

	private bool inScore;
	private bool scrollingOut;

	private Vector3 screenSize;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();

		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (width, height));
		gameObject.GetComponent<RectTransform> ().position = new Vector2 (screenSize.x*1.5f, 0);

		startPos = rec.anchoredPosition;

		audio = GetComponent<AudioSource>();

		inScore = false;
	}

	void Update(){
		if (GameStatus.gameStatus == "Start") {
			StartCoroutine (destroy ());
		} 
		if (GameStatus.gameStatus == "StartMenu") {
			if (inScore == true) {
				if(scrollingOut == false)
				StartCoroutine (scrollOut ());
			}
		}

	}


	void OnMouseUp(){
		if (GameStatus.gameStatus == "StartMenu") {
			StartCoroutine (scrollIn ());
		}
	
	}

	IEnumerator scrollIn(){
		audio.PlayOneShot (sound);
		gameObject.GetComponent<Collider2D> ().enabled = false;
		while (rec.anchoredPosition.x > 0) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, new Vector2(0,0), speed);
			yield return new WaitForSeconds (0.01f);
		}
		GameStatus.gameStatus = "InScore";
		inScore = true;
	}

	IEnumerator scrollOut(){
		audio.PlayOneShot (sound);
		scrollingOut = true;
		while (rec.anchoredPosition.x < startPos.x) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, startPos, speed);
			yield return new WaitForSeconds (0.01f);
		}
		gameObject.GetComponent<Collider2D> ().enabled = true;
		inScore = false;
		scrollingOut = false;
	}

	IEnumerator destroy(){
		while (rec.anchoredPosition.x < startPos.x + 10f) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition,new Vector2(startPos.x + 10f, startPos.y), speed);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}
}
