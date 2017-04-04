using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundBlock : MonoBehaviour {

	public int backgroundID;
	public int price;
	public bool isChosen;
	public bool isOwned;


	void Start () {
		if (PlayerPrefs.GetInt("Background" + backgroundID) == 1)
		{
			isOwned = true;
		}
		if (isOwned)
		{
			transform.Find("Price").GetComponent<Text>().enabled = false;
			if (backgroundID == PlayerPrefs.GetInt("SelectedBackground"))
			{
				isChosen = true;
				transform.Find("Check").GetComponent<Image>().enabled = true;
				GameObject.Find("SelectedBackground").GetComponent<SelectedBackground>().backgroundID = backgroundID;
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

	void Update()
	{
		if (isOwned)
		{
			transform.Find("Price").GetComponent<Text>().enabled = false;
		}
	}

	void OnMouseUp(){
		if (isOwned) {
			disableBlocks ();
			isChosen = true;

			PlayerPrefs.SetInt ("SelectedBackground", backgroundID);
			transform.Find ("Check").GetComponent<Image> ().enabled = true;
			GameObject.Find ("SelectedBackground").GetComponent<SelectedBackground> ().backgroundID = backgroundID;
			Debug.Log ("Chosen Background: " + backgroundID);
		} else {
			BuyAccessStatus.show = true;
			Price.contentType = "Background";
			Price.contentID = backgroundID;
		}
	}

	void disableBlocks(){
		GameObject[] Blocks = GameObject.FindGameObjectsWithTag("BackgroundBlock");
		foreach (GameObject block in Blocks) {
			block.transform.Find ("Check").GetComponent<Image> ().enabled = false;
			block.GetComponent<BackgroundBlock> ().isChosen = false;
		}
	}

}
