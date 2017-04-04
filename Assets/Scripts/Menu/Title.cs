using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{
	private Vector2 startPos;
	private RectTransform rec;
	private bool playingSound;
	private float speed;
	private bool showed;

	private Vector3 screenSize;

	void Start()
	{
		showed = false;
		rec = gameObject.GetComponent<RectTransform>();
		startPos = rec.anchoredPosition;
		StartCoroutine(show());

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
			speed = 45;
		if (pixelScreenSize == new Vector2(1440, 2560))
			speed = 45;
		if (pixelScreenSize == new Vector2(540, 960))
			speed = 15;

		startPos = rec.anchoredPosition;
	}

	void Update()
	{
		if (GameStatus.gameStatus == "StartMenu")
		{
			if (!showed)
				StartCoroutine(show());
		}
		if (GameStatus.gameStatus == "Start") {
			StartCoroutine(destroy());
		}
	}

	IEnumerator show()
	{
		showed = true;
		while (rec.anchoredPosition.x < 0)
		{
			rec.anchoredPosition = Vector2.MoveTowards(rec.anchoredPosition, new Vector2(0, 0), speed);
			yield return new WaitForSeconds(0.01f);
		}
	}


	IEnumerator destroy()
	{
		while (rec.anchoredPosition.x > startPos.x - 10f)
		{
			rec.anchoredPosition = Vector2.MoveTowards(rec.anchoredPosition, new Vector2(startPos.x - 10f, startPos.y), speed);
			yield return new WaitForSeconds(0.01f);
		}
		Destroy(gameObject);
	}
}