using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConnectCheck : MonoBehaviour {

	public bool isChecked;


	void Start () {
		if (PlayerPrefs.GetInt("ConnectOption") == 0)
		{
			activate();
		}
		if (PlayerPrefs.GetInt("ConnectOption") == 1)
		{
			activate();
		}
		else
		{
			if (PlayerPrefs.GetInt("ConnectOption") == 2)
			{
				deactivate();
			}
		}
	}

	void OnMouseUp()
	{
		if (isChecked)
		{
			deactivate();
		}
		else
		{
			activate();
		}
	}

	void activate()
	{
		gameObject.GetComponent<Image>().enabled = true;
		isChecked = true;
		PlayerPrefs.SetInt("ConnectOption", 1);
		PlayerPrefs.Save();
	}

	void deactivate()
	{
		gameObject.GetComponent<Image>().enabled = false;
		isChecked = false;
		PlayerPrefs.SetInt("ConnectOption", 2);
		PlayerPrefs.Save();
	}
}
