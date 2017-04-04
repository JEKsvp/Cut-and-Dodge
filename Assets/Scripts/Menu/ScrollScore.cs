using UnityEngine;
using System.Collections;

public class ScrollScore : MonoBehaviour {

	public float speed;

	private RectTransform rec;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();
	}

	void Update () {

		if (GameStatus.gameStatus == "Playing") {
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
