using UnityEngine;
using System.Collections;

public class PlayerButton : MonoBehaviour {


	void OnMouseUp(){
		GameObject.Find("ChosenBlocksInShop").GetComponent<ChosenBlocks>().status = "PlayerBlocks";
	}

}
