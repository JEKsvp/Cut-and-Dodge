using UnityEngine;
using System.Collections;

public class SizeOfButtonCollider : MonoBehaviour {


	void Start () {
		float width = gameObject.GetComponent<RectTransform> ().rect.width;
		float height = gameObject.GetComponent<RectTransform> ().rect.height;

		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (width,height);
	}
	

	void Update () {
	
	}
}
