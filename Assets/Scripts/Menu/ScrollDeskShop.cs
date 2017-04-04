using UnityEngine;
using System.Collections;

public class ScrollDeskShop : MonoBehaviour {

	public float speed;
	public string direction;

	private Vector2 startPos;
	private RectTransform rec;
	private float tempSpeed;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();

		startPos = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y);

		tempSpeed = speed;
	}
	

	void Update () {

		if (GameStatus.gameStatus == "InShop") {
				if (rec.anchoredPosition.x > 0) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - speed, rec.anchoredPosition.y);
				}
			if (rec.anchoredPosition.x > tempSpeed / 2) {
				tempSpeed = tempSpeed / 2;
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + tempSpeed, rec.anchoredPosition.y);
			}

				if (rec.anchoredPosition.x < 0) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed,rec.anchoredPosition.y);
				}
			if (rec.anchoredPosition.x < tempSpeed / 2) {
				tempSpeed = tempSpeed / 2;
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x - tempSpeed, rec.anchoredPosition.y);
			}

				if (rec.anchoredPosition.y < 0) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
				}

			if (rec.anchoredPosition.y < tempSpeed / 2) {
				tempSpeed = tempSpeed / 2;
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y - tempSpeed);
			}

				if (rec.anchoredPosition.y > 0) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y - speed);
				}
			if (rec.anchoredPosition.y > tempSpeed / 2) {
				tempSpeed = tempSpeed / 2;
				rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + tempSpeed);
			}
		} else {
			if (direction == "up" || direction == "Up") {
				if (rec.anchoredPosition.y < startPos.y) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y + speed);
				}
			}
			if (direction == "down" || direction == "Down") {
				if (rec.anchoredPosition.y > startPos.y) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed, rec.anchoredPosition.y);
				}
			}
			if (direction == "left" || direction == "Left") {
				if (rec.anchoredPosition.x > startPos.x) {
					rec.anchoredPosition -= new Vector2 (speed,0);
				}
			}
			if (direction == "right" || direction == "Right") {
				if (rec.anchoredPosition.x < startPos.x) {
					rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x + speed, rec.anchoredPosition.y);
				}
			}
		}
	
	}
}
