using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		
		switch (Price.contentType) {
		case "Creature":
			if(PlayerPrefs.GetInt("Coins") >= Price.creatures[Price.contentID].GetComponent<Block>().price){
				Price.creatures [Price.contentID].GetComponent<Block> ().isOwned = true;
				PlayerPrefs.SetInt ("Creature"+Price.contentID, 1);
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - Price.creatures [Price.contentID].GetComponent<Block> ().price);
				PlayerPrefs.Save();
				BuyAccessStatus.show = false;
			}
			break;
		case "Player":
				if (PlayerPrefs.GetInt("Coins") >= Price.players[Price.contentID].GetComponent<PlayerBlock>().price)
				{
					Price.players[Price.contentID].GetComponent<PlayerBlock>().isOwned = true;
					PlayerPrefs.SetInt("Player" + Price.contentID, 1);
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Price.players[Price.contentID].GetComponent <PlayerBlock>().price);
					PlayerPrefs.Save();
					BuyAccessStatus.show = false;
				}
				break;
		case "Background":
				if (PlayerPrefs.GetInt("Coins") >= Price.backgrounds[Price.contentID].GetComponent<BackgroundBlock>().price)
				{
					Price.backgrounds[Price.contentID].GetComponent<BackgroundBlock>().isOwned = true;
					PlayerPrefs.SetInt("Background"+Price.contentID, 1);
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Price.backgrounds[Price.contentID].GetComponent<BackgroundBlock>().price);
					PlayerPrefs.Save();
					BuyAccessStatus.show = false;
				}
				break;
		}
	}
}
