using UnityEngine;
using System.Collections;

public class CreditsWindow : MonoBehaviour {

	private Vector2 startPos;
	private RectTransform rec;
	private bool inCredits;

	public AudioClip sound;
	private AudioSource audio;

	private bool scrollingOut;

	void Start()
	{
		rec = gameObject.GetComponent<RectTransform>();
		startPos = rec.anchoredPosition;
		inCredits = false;

		audio = GetComponent<AudioSource>();
	}


	void Update()
	{
		if (GameStatus.gameStatus == "InCredits")
		{
			if (!inCredits)
			{
				StartCoroutine(scrollIn());
			}
		}
		else
		{
			if (inCredits)
			{
				if (!scrollingOut)
					StartCoroutine(scrollOut());
			}
		}
		if (GameStatus.gameStatus == "Start")
		{
			Destroy(gameObject);
		}
	}


	IEnumerator scrollIn()
	{
		audio.PlayOneShot(sound);
		inCredits = true;
		for (int i = 0; i < 20; i++) {
			gameObject.transform.localScale += new Vector3(0, 0.05f, 0);
			yield return new WaitForSeconds(0.01f);
		}
	}

	IEnumerator scrollOut()
	{
		scrollingOut = true;
		audio.PlayOneShot(sound);
		for (int i = 0; i < 20; i++)
		{
			gameObject.transform.localScale -= new Vector3(0, 0.05f, 0);
			yield return new WaitForSeconds(0.01f);
		}
		inCredits = false;
		scrollingOut = false;
	}
}
