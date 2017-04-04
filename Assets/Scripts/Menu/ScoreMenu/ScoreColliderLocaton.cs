using UnityEngine;
using System.Collections;

public class ScoreColliderLocaton : MonoBehaviour {

	public float locationNumber;
	public float partOfsize;

	private Vector2 size;


	void Start () {
		size = new Vector2 (gameObject.GetComponent<RectTransform> ().rect.width, gameObject.GetComponent<RectTransform> ().rect.height);
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2(size.x / partOfsize, size.y);
		gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (size.y / -locationNumber, 0);
	}


	void Update () {

	}
}
