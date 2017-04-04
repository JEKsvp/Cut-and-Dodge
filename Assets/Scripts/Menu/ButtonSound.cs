using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour {

	private AudioSource click;

	void Start () {
		click = gameObject.GetComponent<AudioSource> ();
	}
	
	void OnMouseDown(){
		click.Play ();
	}
}
