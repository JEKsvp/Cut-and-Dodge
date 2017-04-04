using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Block : MonoBehaviour {

	public int skinid;
	public int price;
	public bool isChosen;
	public bool isOwned;


	void Start(){

		if (PlayerPrefs.GetInt ("Creature" + skinid) == 1) {
			isOwned = true;
		}
		if (isOwned) {
			transform.Find ("Price").GetComponent<Text> ().enabled = false;
			if (skinid == PlayerPrefs.GetInt ("ChosenEnemySkin")) {
				isChosen = true;
				transform.Find ("Check").GetComponent<Image> ().enabled = true;
				GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ().skinId = skinid;
			} else {
				isChosen = false;
				transform.Find ("Check").GetComponent<Image> ().enabled = false;
			}
		} else {
			isChosen = false;
			transform.Find ("Check").GetComponent<Image> ().enabled = false;
		}
	}

	void Update(){
		if (isOwned) {
			transform.Find ("Price").GetComponent<Text> ().enabled = false;
		}
	}

	void OnMouseUp(){
		if (isOwned) {
			disableBlocks();
			isChosen = true;

			PlayerPrefs.SetInt ("ChosenEnemySkin", skinid);
			transform.Find ("Check").GetComponent<Image> ().enabled = true;
			GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ().skinId = skinid;
		} else {
			BuyAccessStatus.show = true;
			Price.contentType = "Creature";
			Price.contentID = skinid;
		}
	}

	void disableBlocks(){
		GameObject[] Blocks = GameObject.FindGameObjectsWithTag("CreatureBlock");
		foreach (GameObject block in Blocks) {
			block.transform.Find ("Check").GetComponent<Image> ().enabled = false;
			block.GetComponent<Block> ().isChosen = false;
		}
	}

}
