using UnityEngine;
using System.Collections;

public class ScrollObject : MonoBehaviour {

	public float speed;
	public string direction;
	public bool goIn;

	public string gameStatus1;
	public string gameStatus2;

	private RectTransform rec;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();

	}


	void Update () {

		//Выезд
		if (GameStatus.gameStatus == gameStatus1 || GameStatus.gameStatus == gameStatus2 && goIn) {
			if (rec.anchoredPosition.x > 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - speed, rec.anchoredPosition.y);
			}
			if (rec.anchoredPosition.x < 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed,rec.anchoredPosition.y);
			}
			if (rec.anchoredPosition.y < 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
			}
			if (rec.anchoredPosition.y < 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y +speed);
			}

		}

		//Въезд
		if (GameStatus.gameStatus != gameStatus1 || GameStatus.gameStatus != gameStatus2 && !goIn) {
			if (direction == "up" || direction == "Up") {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
			}
			if (direction == "down" || direction == "Down") {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed, rec.anchoredPosition.y);
			}
			if (direction == "left" || direction == "Left") {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - speed, rec.anchoredPosition.y);
			}
			if (direction == "right" || direction == "Right") {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed, rec.anchoredPosition.y);
			}
			StartCoroutine (destroyObject());
		}
}

	IEnumerator destroyObject(){
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
