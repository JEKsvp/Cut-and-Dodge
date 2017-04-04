using UnityEngine;
using System.Collections;

public class ColliderLocation : MonoBehaviour {

	public float locationNumber;
	public float partOfsize;

	private Vector2 size;


	void Start () {
		size = new Vector2 (gameObject.GetComponent<RectTransform> ().rect.width, gameObject.GetComponent<RectTransform> ().rect.height);
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2(size.x, size.y / partOfsize);
		gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (0, size.y / locationNumber);
	}


	void Update () {
	
	}
}
