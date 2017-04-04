using UnityEngine;
using System.Collections;

public class BackgroundSize : MonoBehaviour {


	void Start () {
		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		Vector2 pixelScreenSize = new Vector2 (width, height);
		if(pixelScreenSize == new Vector2(768,1024))
			gameObject.transform.localScale += new Vector3 (0.09f, 0, 0);
	}

}
