using UnityEngine;
using System.Collections;

public class Skin : MonoBehaviour {

	public int id;

	void Start(){
		
	}

	void OnMouseUp(){

	GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ().skinId = id;
	}
}
