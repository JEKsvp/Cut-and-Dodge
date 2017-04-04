using UnityEngine;
using System.Collections;

public class EnemyTail : MonoBehaviour {

	public GameObject front;

	private float speed;
	private EnemyHead head;

	private GameObject temp;
	private Vector3 moveDirection;


	void Start () {
		SelectedSkin selectedSkin = GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ();

		gameObject.GetComponent<SpriteRenderer> ().sprite = selectedSkin.tailSprites [selectedSkin.skinId];

		transform.position = GameObject.FindGameObjectWithTag ("EnemyHead").transform.position;
	}

	


	void Update() {

		speed = EnemyHead.speed / 10.0f;


		if (front != null) {
			transform.position = Vector3.Lerp (transform.position, front.transform.position, speed);
			moveDirection = front.transform.position - transform.position; 
			if (moveDirection != Vector3.zero) {
				float angle = Mathf.Atan2 (-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
		}
		if (front == null || front.activeSelf == false) {
			TailPool.goInPool(gameObject);
		}
	}

}