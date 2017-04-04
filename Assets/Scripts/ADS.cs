using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class ADS : MonoBehaviour {

	private GameObject restartButton;
	private GameObject homeButton;
	private GameObject shareButton;
	public GameObject darkImage;

	private const string ads = "ca-app-pub-9338092252763892/1120483561";
	private InterstitialAd ad;
	private bool showed;
	private bool loading;
	private bool isInternetConnected;

	void Start() {

		restartButton = GameObject.Find("RestartButton");
		homeButton = GameObject.Find("HomeButton");
		shareButton = GameObject.Find("ShareButton");

		isInternetConnected = false;

		if (PlayerPrefs.GetInt("GameOvers") % 7 == 0 && PlayerPrefs.GetInt("GameOvers") != 0)
		{
			loading = true;
			ad = new InterstitialAd(ads);
			AdRequest request = new AdRequest.Builder().Build();
			ad.LoadAd(request);
		}
		else {
			loading = false;
		}

			showed = false;
		//StartCoroutine(internetConnection());
	}

	void Update() {

		if (loading)
		{
			if (!showed && ad.IsLoaded() && GameStatus.gameStatus == "GameOver")
			{
				ad.Show();
				showed = true;
			}
		}
	}


	//private IEnumerator internetConnection() {
	//	WWW get = new WWW("https://www.google.com/");
	//	yield return new WaitForSeconds(3f);
	//	if (get.responseHeaders.Count > 0) {
	//		Debug.Log(get.responseHeaders.Count);
	//		isInternetConnected = true;
	//	}
	//}

	//IEnumerator StartLoadADS() {
	//	restartButton.GetComponent<Collider2D>().enabled = false;
	//	homeButton.GetComponent<Collider2D>().enabled = false;
	//	shareButton.GetComponent<Collider2D>().enabled = false;
	//	darkImage.SetActive(true);

	//	ad = new InterstitialAd(ads);
	//	AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("33FDBFC590AE4812").Build();
	//	ad.LoadAd(request);
	//	yield return new WaitForSeconds(5f);

	//	restartButton.GetComponent<Collider2D>().enabled = true;
	//	homeButton.GetComponent<Collider2D>().enabled = true;
	//	shareButton.GetComponent<Collider2D>().enabled = true;
	//	darkImage.SetActive(false);
	//}
}
