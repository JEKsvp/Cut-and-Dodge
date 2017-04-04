using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopScore : MonoBehaviour {


	void Start () {
		gameObject.GetComponent<Text> ().text = (float) System.Math.Round(SPlayerPrefs.GetFloat ("Score")) + "";
	}

}
