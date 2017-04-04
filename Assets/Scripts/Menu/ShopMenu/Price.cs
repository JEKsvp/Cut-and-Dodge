using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Price : MonoBehaviour {

	public static GameObject[] creatures;
	public static GameObject[] backgrounds;
	public static GameObject[] players;
	private int[] creaturePrices;
	private int[] playerPrices;
	private int[] backgroundPrices;
	private int[] musicPrices;

	public static string contentType; 
	private string tempContentType;
	public static int contentID;
	private int tempContentID;
	private Text price;

	private GameObject buyButton;

	void Start () {
		buyButton = GameObject.Find ("BuyButton");

		price = gameObject.GetComponent<Text> ();
		creaturePrices = new int[4];
		creatures = new GameObject[4];
		creatures [0] = GameObject.Find ("CreatureBlock1");
		creatures [1] = GameObject.Find ("CreatureBlock2");
		creatures [2] = GameObject.Find ("CreatureBlock3");
		creatures [3] = GameObject.Find ("CreatureBlock4");
		for (int i = 0; i < 4; i++) {
			creaturePrices [i] = creatures [i].GetComponent<Block> ().price;
		}

		backgroundPrices = new int[4];
		backgrounds = new GameObject[4];
		backgrounds[0] = GameObject.Find("BackgroundBlock1");
		backgrounds[1] = GameObject.Find("BackgroundBlock2");
		backgrounds[2] = GameObject.Find("BackgroundBlock3");
		backgrounds[3] = GameObject.Find("BackgroundBlock4");
		for (int i = 0; i < 4; i++) {
			backgroundPrices[i] = backgrounds[i].GetComponent<BackgroundBlock>().price;
		}

		playerPrices = new int[4];
		players = new GameObject[4];
		players[0] = GameObject.Find("PlayerBlock1");
		players[1] = GameObject.Find("PlayerBlock2");
		players[2] = GameObject.Find("PlayerBlock3");
		for (int i = 0; i < 3; i++) {
			playerPrices[i] = players[i].GetComponent<PlayerBlock>().price;
		}

	}


	void Update () {
		if (contentType != tempContentType || tempContentID != contentID) {
			switch (contentType) {
			case "Creature":
					if (PlayerPrefs.GetInt("Coins") < creaturePrices[contentID])
					{
						buyButton.GetComponent<Collider2D>().enabled = false;
						buyButton.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
					}
					else
					{
						buyButton.GetComponent<Collider2D>().enabled = true;
						buyButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
					}
					price.text = creaturePrices [contentID] + "";
				break;
			case "Player":
					if (PlayerPrefs.GetInt("Coins") < playerPrices[contentID])
					{
						buyButton.GetComponent<Collider2D>().enabled = false;
						buyButton.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
					}
					else
					{
						buyButton.GetComponent<Collider2D>().enabled = true;
						buyButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
					}
					price.text = playerPrices[contentID] + "";
					break;
			case "Background":
					if (PlayerPrefs.GetInt("Coins") < backgroundPrices[contentID])
					{
						buyButton.GetComponent<Collider2D>().enabled = false;
						buyButton.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
					}
					else
					{
						buyButton.GetComponent<Collider2D>().enabled = true;
						buyButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
					}
					price.text = backgroundPrices[contentID] + "";
				break;
			case "Music":
				break;
			}
		}
		tempContentType = contentType;
		tempContentID = contentID;
	}
}
