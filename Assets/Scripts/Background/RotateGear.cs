using UnityEngine;
using System.Collections;

public class RotateGear : MonoBehaviour {

	public string direction;
	public float speed;

	void OnEnable () {
		StartCoroutine (Rotate (direction, speed));
	}


	IEnumerator Rotate(string dir, float speed){
		 
		if (direction == "right") {
			while (true) {
				gameObject.transform.Rotate (new Vector3 (0, 0, -speed));
				yield return new WaitForSeconds (0.01f);
			}
		}
		if (direction == "left") {
			while (true) {
				gameObject.transform.Rotate (new Vector3 (0, 0, speed));
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}
