using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public bool active;
	public float speed;
	public string direction;

	private Vector3 rightRotation;
	private Vector3 leftRotation;

	void Start () {
		rightRotation = new Vector3 (0, 0, -1f);
		leftRotation = new Vector3 (0, 0, 1f);
	}

	void Update () {

		if(active){
			if (direction == "right") {
				transform.Rotate (rightRotation * Time.deltaTime * speed);
			}
			if (direction == "left") {
				transform.Rotate (leftRotation * Time.deltaTime * speed);
			}
		}
	}
}
