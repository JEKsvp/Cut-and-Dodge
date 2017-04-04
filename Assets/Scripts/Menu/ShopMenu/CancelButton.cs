using UnityEngine;
using System.Collections;

public class CancelButton : MonoBehaviour {

	void OnMouseUp(){
		BuyAccessStatus.show = false;
	}
}
