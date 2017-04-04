using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {

	private Vector2 startPos;
	private RectTransform rec;
	private AudioSource audio;
	private bool playingSound;
	private float speed;
	private bool showed;

	private Vector3 screenSize;

	void Start () {
		showed = false;
		rec = gameObject.GetComponent<RectTransform>();
		startPos = rec.anchoredPosition;
		audio = gameObject.GetComponent<AudioSource>();
		playingSound = false;

		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(width, height));
		gameObject.GetComponent<RectTransform>().position = new Vector2(-screenSize.x * 2.5f, 0);

		speed = 10;
		Vector2 pixelScreenSize = new Vector2(width, height);
		if (pixelScreenSize == new Vector2(320, 480))
			speed = 8;
		if (pixelScreenSize == new Vector2(480, 800))
			speed = 13;
		if (pixelScreenSize == new Vector2(480, 854))
			speed = 13;
		if (pixelScreenSize == new Vector2(600, 1024))
			speed = 17;
		if (pixelScreenSize == new Vector2(720, 1280))
			speed = 22;
		if (pixelScreenSize == new Vector2(800, 1280))
			speed = 26;
		if (pixelScreenSize == new Vector2(1080, 1920))
			speed = 32;
		if (pixelScreenSize == new Vector2(768, 1024))
			speed = 22;
		if (pixelScreenSize == new Vector2(600, 1024))
			speed = 20;
		if (pixelScreenSize == new Vector2(1600, 2560))
			speed = 40;
		if (pixelScreenSize == new Vector2(1440, 2560))
			speed = 40;
		if (pixelScreenSize == new Vector2(540, 960))
			speed = 15;

		startPos = rec.anchoredPosition;

	}

	void Update() {
		if (GameStatus.gameStatus == "StartMenu")
		{
			if (!showed)
				StartCoroutine(show());
		}
		if (GameStatus.gameStatus == "Start")
		{
			Destroy(gameObject);
		}
	}
	IEnumerator show() {
		showed = true;
		while (rec.anchoredPosition.x < 0)
		{
			if (rec.anchoredPosition.x < Mathf.Abs(screenSize.x)) {
				if (!playingSound)
					StartCoroutine(playSound());
				playingSound = true;
			}
			rec.anchoredPosition = Vector2.MoveTowards(rec.anchoredPosition, new Vector2(0, 0), speed);
			yield return new WaitForSeconds(0.01f);
		}
		playingSound = false;
		yield return new WaitForSeconds(0.5f);
		audio.Play();
		while (rec.anchoredPosition.x > startPos.x)
		{
			rec.anchoredPosition = Vector2.MoveTowards(rec.anchoredPosition, startPos, speed);
			yield return new WaitForSeconds(0.01f);
		}
		Destroy(gameObject);
	}
	IEnumerator playSound() {
		yield return new WaitForSeconds(0.4f);
		audio.Play();
	}
}
