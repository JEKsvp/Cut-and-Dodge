using UnityEngine;
using System.Collections;

public class CreateCoins : MonoBehaviour {

	public static int coins;

	private Vector3 screenSize;
	private float headNumber;

	void Start () {
		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (width, height));

		StartCoroutine (createCoin ());
	}


	void Update () {
	}

	void FixedUpdate(){
		
	}

	public IEnumerator createCoin(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (10, 25f));
			GameObject coin = Instantiate (Resources.Load ("Prefabs/Coin")) as GameObject;
			coin.transform.position = new Vector2 (Random.Range (-screenSize.x, screenSize.x), Random.Range (-screenSize.y, screenSize.y));
			for (int i = 0; i < 10; i++) {
				if (coin != null) {
					coin.transform.localScale += new Vector3 (0.015f, 0.015f, 0);
					yield return new WaitForSeconds (0.02f);
				}
			}

			yield return new WaitForSeconds (Random.Range (5f, 10f));
			if (coin != null) {
				Destroy (coin);
			}
		}
	}
}
