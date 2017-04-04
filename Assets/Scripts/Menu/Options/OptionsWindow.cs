using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsWindow : MonoBehaviour {

	private Vector2 startPos;
	private RectTransform rec;
	private bool inOptions;
	public GameObject musicChek;
	public GameObject soundChek;
	public GameObject connentCheck;

	public AudioClip sound;
	private AudioSource audio;

	private bool scrollingOut;
	private bool scrollingIn;

	void Start () {
		rec = gameObject.GetComponent<RectTransform> ();
		startPos = rec.anchoredPosition;
		inOptions = false;
		scrollingIn = false;

		audio = GetComponent<AudioSource>();
	}
	

	void Update () {
		if (GameStatus.gameStatus == "InOptions") {
			if (!inOptions) {
				StartCoroutine (scrollIn ());
			}
		} else {
			if (inOptions && !scrollingIn){
				if(!scrollingOut)
				StartCoroutine(scrollOut());
			}
		}
		if (GameStatus.gameStatus == "Start") {
			Destroy (gameObject);
		}
	}


	IEnumerator scrollIn(){
		audio.PlayOneShot (sound);
		scrollingIn = true;
		inOptions = true;
		musicChek.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		soundChek.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		connentCheck.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		while (rec.anchoredPosition.x < 0) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, new Vector2(0,0), 60);
			yield return new WaitForSeconds (0.01f);
		}
		scrollingIn = false;
	}

	IEnumerator scrollOut(){
		scrollingOut = true;
		audio.PlayOneShot (sound);
		while (rec.anchoredPosition.x > startPos.x) {
			rec.anchoredPosition = Vector2.MoveTowards (rec.anchoredPosition, startPos, 60);
			yield return new WaitForSeconds (0.01f);
		}
		musicChek.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		soundChek.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		connentCheck.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		inOptions = false;
		scrollingOut = false;
	}
}
