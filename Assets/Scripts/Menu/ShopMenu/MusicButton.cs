using UnityEngine;
using System.Collections;

public class MusicButton : MonoBehaviour {

	void OnMouseUp(){
		GameObject.Find("ChosenBlocksInShop").GetComponent<ChosenBlocks>().status = "MusicBlocks";
	}
}
