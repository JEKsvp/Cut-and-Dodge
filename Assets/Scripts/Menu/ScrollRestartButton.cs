using UnityEngine;
using System.Collections;

public class ScrollRestartButton : MonoBehaviour {

	public float speed;
	public static bool isPlaying;

	private RectTransform rec;

	void Start () {
		isPlaying = false;

		rec = gameObject.GetComponent<RectTransform> ();

	}

	void Update () {
	
		if (GameStatus.gameStatus == "GameOver") {
			if (rec.anchoredPosition.x > 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - speed, rec.anchoredPosition.y);
			}
			if (rec.anchoredPosition.x < 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed,rec.anchoredPosition.y);
			}
			if (rec.anchoredPosition.y > 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y - speed);
			}
			if (rec.anchoredPosition.y < 0) {
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
			}

		}
	}

}
