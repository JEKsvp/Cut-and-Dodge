using UnityEngine;
using System.Collections;

public class SelectedSkin : MonoBehaviour {

	public int skinId;
	private int tempSkinId;

	public Sprite[] headSprites;
	public Sprite[] backSprites;
	public Sprite[] tailSprites;
	public Texture[] backTextures;
	public Material explosionMaterial;


	void Start () {

		changeSkin ();

		tempSkinId = skinId;

	}
	

	void Update () {
		if (tempSkinId != skinId) {
			changeSkin ();
			tempSkinId = skinId;
		}
	
	}

	void changeSkin(){
		GameObject headSprite = GameObject.FindGameObjectWithTag ("HeadSprite");
		headSprite.GetComponent<SpriteRenderer> ().sprite = headSprites [skinId];
		foreach (GameObject tempHeadSprite in HeadPool.headSpritesPool) {
			tempHeadSprite.GetComponent<SpriteRenderer>().sprite = headSprites[skinId];
		}

		GameObject[] backs = GameObject.FindGameObjectsWithTag ("Back");
		foreach (GameObject back in backs) {
			back.GetComponent<SpriteRenderer> ().sprite = backSprites [skinId];
		}

		GameObject tail = GameObject.FindGameObjectWithTag ("Tail");
		tail.GetComponent<SpriteRenderer> ().sprite = tailSprites [skinId];
		for(int i = 0; i < 9; i++) {
			TailPool.tailPool[i].GetComponent<SpriteRenderer>().sprite = tailSprites[skinId];
		}

		explosionMaterial.mainTexture = backTextures [skinId];
	}
}
