using UnityEngine;
using System.Collections;

public class ScoreTextSize : MonoBehaviour {

	void Start () {
		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;

		Vector2 pixelScreenSize = new Vector2(width, height);
		if (pixelScreenSize == new Vector2(320, 480))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
		if (pixelScreenSize == new Vector2(480, 800))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		if (pixelScreenSize == new Vector2(480, 854))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		if (pixelScreenSize == new Vector2(800, 1280))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 1f);
		if (pixelScreenSize == new Vector2(1080, 1920))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1f);
		if (pixelScreenSize == new Vector2(768, 1024))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		if (pixelScreenSize == new Vector2(600, 1024))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		if (pixelScreenSize == new Vector2(1600, 2560))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.7f, 1.7f, 1f);
		if (pixelScreenSize == new Vector2(1440, 2560))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.7f, 1.7f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
