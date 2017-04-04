using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour {


	void OnMouseDown(){
		gameObject.transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
	}

	void OnMouseUp(){
		gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
	}

}
