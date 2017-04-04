using UnityEngine;
using System.Collections;

public class ScrollShopButton : MonoBehaviour {

	public float speed;
	public string direction;

	private RectTransform rec;


	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();
	}


	void Update () {
		if (GameStatus.gameStatus != "Start" && GameStatus.gameStatus != "InShop") {
			if (direction == "up" || direction == "Up") {
				StartCoroutine (goUp());
			}
			if (direction == "down" || direction == "Down") {
				StartCoroutine (goDown());
			}
			if (direction == "left" || direction == "Left") {
				StartCoroutine (goLeft());
			}
			if (direction == "right" || direction == "Right") {
				StartCoroutine (goRight());
			}
		}
	}

	IEnumerator goLeft(){
		for(int i = 0; i < 25; i++){
			rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - speed, rec.anchoredPosition.y);
			yield return new WaitForSeconds (0.01f);
		}

		Destroy (gameObject);
	}

	IEnumerator goRight(){
		for(int i = 0; i < 25; i++){
			rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed, rec.anchoredPosition.y);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}

	IEnumerator goUp(){
		for(int i = 0; i < 25; i++){
			rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}

	IEnumerator goDown(){
		for(int i = 0; i < 25; i++){
			rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y - speed);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}
}
