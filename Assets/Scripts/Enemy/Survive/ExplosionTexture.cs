using UnityEngine;
using System.Collections;

public class ExplosionTexture : MonoBehaviour {

	public GameObject selectedSkin;

	void Start () {
		gameObject.GetComponent<ParticleSystemRenderer> ().material = selectedSkin.GetComponent<SelectedSkin> ().explosionMaterial;
	}


	void Update () {
	
	}
}
