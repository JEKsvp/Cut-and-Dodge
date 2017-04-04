using UnityEngine;
using System.Collections;

public class CancelRate : MonoBehaviour {

	public GameObject rate;

	void OnMouseUp() {
		rate.SetActive(false);
	}

}
