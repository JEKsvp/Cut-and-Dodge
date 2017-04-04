using UnityEngine;
using System.Collections;

public class CreatureButton : MonoBehaviour {

	void OnMouseUp(){
		GameObject.Find("ChosenBlocksInShop").GetComponent<ChosenBlocks>().status = "CreatureBlocks";
	}
}
