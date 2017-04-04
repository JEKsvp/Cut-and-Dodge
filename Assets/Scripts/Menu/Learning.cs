using UnityEngine;
using System.Collections;

public class Learning : MonoBehaviour {

	public GameObject slide1;
	public GameObject slide2;
	public GameObject slide3;

	private int slidenumber;


	void OnEnable() {
		slidenumber = 2;
		slide1.SetActive(true);
		slide2.SetActive(false);
		slide3.SetActive(false);
	}

	void Update() {
		GameObject.Find("Player").GetComponent<CircleCollider2D>().enabled = false;
	}

	void OnDisable() {
		GameObject.Find("Player").GetComponent<CircleCollider2D>().enabled = true;
	}

	void OnMouseUp() {
		switch (slidenumber) {
			case 1:
				slidenumber += 1;
				slide1.SetActive(true);
				slide2.SetActive(false);
				slide3.SetActive(false);
				break;
			case 2:
				slidenumber += 1;
				slide1.SetActive(false);
				slide2.SetActive(true);
				slide3.SetActive(false);
				break;
			case 3:
				slidenumber += 1;
				slide1.SetActive(false);
				slide2.SetActive(false);
				slide3.SetActive(true);
				break;
			case 4:
				gameObject.SetActive(false);
				break;

		}
	}
}
