using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBlock : MonoBehaviour {

	public int skinid;
	public int price;
	public bool isChosen;
	public bool isOwned;


	void Start () {
		if (PlayerPrefs.GetInt("Player" + skinid) == 1)
		{
			isOwned = true;
		}
		if (isOwned)
		{
			transform.Find("Price").GetComponent<Text>().enabled = false;
			if (skinid == PlayerPrefs.GetInt("SelectedPlayerSkin"))
			{
				isChosen = true;
				transform.Find("Check").GetComponent<Image>().enabled = true;
				GameObject.Find("PlayerSkin").GetComponent<PlayerSkin>().skinId = skinid;
			}
			else
			{
				isChosen = false;
				transform.Find("Check").GetComponent<Image>().enabled = false;
			}
		}
		else
		{
			isChosen = false;
			transform.Find("Check").GetComponent<Image>().enabled = false;
		}
	}
	

	void Update () {
		if (isOwned)
		{
			transform.Find("Price").GetComponent<Text>().enabled = false;
		}
	}

	void OnMouseUp()
	{
		if (isOwned)
		{
			disableBlocks();
			isChosen = true;

			PlayerPrefs.SetInt("SelectedPlayerSkin", skinid);
			transform.Find("Check").GetComponent<Image>().enabled = true;
			GameObject.Find("PlayerSkin").GetComponent<PlayerSkin>().skinId = skinid;
		}
		else
		{
			BuyAccessStatus.show = true;
			Price.contentType = "Player";
			Price.contentID = skinid;
		}
	}

	void disableBlocks()
	{
		GameObject[] Blocks = GameObject.FindGameObjectsWithTag("PlayerBlock");
		foreach (GameObject block in Blocks)
		{
			block.transform.Find("Check").GetComponent<Image>().enabled = false;
			block.GetComponent<PlayerBlock>().isChosen = false;
		}
	}
}
