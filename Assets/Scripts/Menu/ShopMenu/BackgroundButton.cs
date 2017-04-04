using UnityEngine;
using System.Collections;

public class BackgroundButton : MonoBehaviour {

	void OnMouseUp(){
		GameObject.Find("ChosenBlocksInShop").GetComponent<ChosenBlocks>().status = "BackgroundBlocks";
	}
}
