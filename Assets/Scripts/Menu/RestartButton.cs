using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RestartButton : MonoBehaviour {


	void OnMouseUp(){
		PlayerPrefs.SetInt("Restart", 1);
		SceneManager.LoadScene ("Survive");
	}


}
