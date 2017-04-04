using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayerSurvive : MonoBehaviour {

	public Vector3 startPosition;
	private Vector3 position;

	public AudioClip coinSound;
	public AudioClip swoosh;
	private bool isSwooshPlaying;
	private AudioSource audio;
	public static bool isPlaying;
	private bool shakingCamera;

	private Vector3 screenSize;

	void Start() {
		gameObject.transform.position = GameObject.Find("Player").transform.position;

		shakingCamera = false;

		isPlaying = false;

		isSwooshPlaying = false;

		audio = GetComponent<AudioSource>();

		gameObject.GetComponent<Collider2D>().enabled = false;

		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(width, height));

	}

	void Update() {
		if (!isPlaying)
		{
			if (GameStatus.gameStatus == "Start")
			{
				StartCoroutine(goInScene());
				if (transform.localScale.x <= 0.13)
				{
					gameObject.GetComponent<Collider2D>().enabled = true;
				}
			}
		}
	}

	void FixedUpdate() { }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Back") {
			StartCoroutine(createExplosion(gameObject));
			if (!isSwooshPlaying) {
				StartCoroutine(playSwoosh());
			}
			if (!Shake.shakingCamera) {
				StartCoroutine(GameObject.Find("Main Camera").GetComponent<Shake>().shakeCamera());
			}
		}

		if (col.gameObject.tag == "Coin") {
			StartCoroutine(GameObject.Find("CoinsInGame").GetComponent<CoinsInGame>().showCoins());
			audio.PlayOneShot(coinSound);
		}

		if (col.gameObject.tag == "EnemyHead" || col.gameObject.tag == "Tail") {
			destroyScene();
		}
	}

	IEnumerator createExplosion(GameObject gameObject) {
		GameObject explosion = Instantiate(Resources.Load("Prefabs/Explosion")) as GameObject;
		explosion.transform.position = gameObject.transform.position;
		explosion.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
		yield return new WaitForSeconds(5f);
		Destroy(explosion);
	}

	IEnumerator createPlayerExplosion(GameObject gameObject) {
		GameObject playerExplosion = Instantiate(Resources.Load("Prefabs/PlayerExplosion" + GameObject.Find("PlayerSkin").GetComponent<PlayerSkin>().skinId)) as GameObject;
		playerExplosion.transform.position = gameObject.transform.position;
		playerExplosion.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
		yield return new WaitForSeconds(5f);
		Destroy(playerExplosion);
	}

	//Логика уничтожения объектов на сцене
	public void destroyScene() {

		StartCoroutine(createPlayerExplosion(gameObject));

		//Запись лучшего счета
		if (SPlayerPrefs.GetFloat("Score") < GameObject.Find("Score").GetComponent<ScoreCounter>().score)
		{
			SPlayerPrefs.SetFloat("Score", GameObject.Find("Score").GetComponent<ScoreCounter>().score);
			SPlayerPrefs.Save();
		}

		Destroy(gameObject);

		GameObject[] heads = GameObject.FindGameObjectsWithTag("EnemyHead");
		GameObject[] headSprites = GameObject.FindGameObjectsWithTag("HeadSprite");
		GameObject[] backs = GameObject.FindGameObjectsWithTag("Back");
		GameObject[] tails = GameObject.FindGameObjectsWithTag("Tail");

		foreach (GameObject head in heads) {
			StartCoroutine(createExplosion(head));
			Destroy(head);
		}

		foreach (GameObject headSprite in headSprites) {
			Destroy(headSprite);
		}

		foreach (GameObject back in backs) {
			StartCoroutine(createExplosion(back));
			Destroy(back);
		}

		foreach (GameObject tail in tails) {
			StartCoroutine(createExplosion(tail));
			Destroy(tail);
		}

		EnemyHead.speed = 0;

		GameStatus.gameStatus = "GameOver";
	}


	IEnumerator goInScene() {
		if (transform.position.y != -screenSize.y / 1.5f) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -screenSize.y / 1.5f, 0), 0.1f);
			if (transform.localScale.x >= 0.13) {
				transform.localScale += new Vector3(-0.005f, -0.005f, 0f);
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

	IEnumerator playSwoosh() {
		isSwooshPlaying = true;
		audio.PlayOneShot(swoosh);
		yield return new WaitForSeconds(0.1f);
		isSwooshPlaying = false;
	}
}
