using UnityEngine;
using System.Collections;

public class HeadSprite : MonoBehaviour {

	public GameObject head;
	public bool secondaryHead;
	private bool destroing;

	void Start () {
		destroing = false;
		SelectedSkin selectedSkin = GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = selectedSkin.headSprites [selectedSkin.skinId];
	}

	void OnEnable() {
		destroing = false;
	}


	void Update() {
		if (head != null && head.activeSelf) {
			transform.position = Vector3.Lerp (transform.position, head.transform.position, 0.5f);

			Vector3 moveDirection = head.transform.position - transform.position; 
			if (moveDirection != Vector3.zero) {
				float angle = Mathf.Atan2 (-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
		} else {
			if (secondaryHead && !head.activeSelf)
			{
				if(!destroing)
				StartCoroutine(slowDestoy());
			}
			else
				HeadPool.goHeadSpriteInPool(gameObject);
		}
	}

	IEnumerator slowDestoy() {
		destroing = true;
		for (int i = 0; i < 7; i++) {
			gameObject.transform.localScale -= new Vector3(0.02f, 0.02f, 0);
			yield return new WaitForSeconds(0.01f);
		}
		HeadPool.goHeadSpriteInPool(gameObject);
		destroing = false;
	}
}
