using UnityEngine;
using System.Collections;

public class MainGearLocation : MonoBehaviour {

	private Vector3 screenSize;

	private RectTransform rec;

	void Start () {
		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;

		Vector2 pixelScreenSize = new Vector2 (width, height);
		if(pixelScreenSize == new Vector2(320,480))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1.12f, 1f);
		if(pixelScreenSize == new Vector2(480,800))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		if(pixelScreenSize == new Vector2(480,854))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 0.97f, 1f);
		if(pixelScreenSize == new Vector2(800,1280))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1.09f, 1f);
		if(pixelScreenSize == new Vector2(1080,1920))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 0.98f, 1f);
		if(pixelScreenSize == new Vector2(768,1024))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.9f, 1.15f, 1f);
		if(pixelScreenSize == new Vector2(600,1024))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		if(pixelScreenSize == new Vector2(1600,2560))
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1.1f, 1f);
		if (pixelScreenSize == new Vector2(540, 960))
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 0.97f, 1f);




		screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (width, height));
		gameObject.GetComponent<RectTransform> ().position = new Vector2 (0, -screenSize.y);


		rec = gameObject.GetComponent<RectTransform> ();
	}

	void Update(){
		if (GameStatus.gameStatus == "Start") {
			StartCoroutine (goDown());
		}
	}

	IEnumerator goDown(){
		for(int i = 0; i < 25; i++){
			rec.anchoredPosition = new Vector2 (rec.anchoredPosition.x, rec.anchoredPosition.y - 20f);
			yield return new WaitForSeconds (0.01f);
		}
		Destroy (gameObject);
	}

}
