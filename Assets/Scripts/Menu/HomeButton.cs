using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour {

	void OnMouseUp()
	{
		SceneManager.LoadScene("Survive");
	}
}
