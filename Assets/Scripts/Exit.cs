using UnityEngine;
using System.Collections;
using TheNextFlow.UnityPlugins;

public class Exit : MonoBehaviour {

	private int numberOfTaps;

	void Start() {
		numberOfTaps = 0;
	}

	void Update()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				StartCoroutine(tap());
				if(numberOfTaps >= 2)
				Application.Quit();
			}
		}
	}

	IEnumerator tap() {
		numberOfTaps += 1;
		AndroidNativePopups.OpenToast("Tap again to EXIT", AndroidNativePopups.ToastDuration.Short);
		yield return new WaitForSeconds(2f);
		numberOfTaps = 0;
	}
}
