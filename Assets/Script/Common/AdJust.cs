using UnityEngine;
using System.Collections;

public class AdJust : MonoBehaviour {
	const float widthPerHeight = 17.4f / 9.0f;
	private float lastWidth = 0;
	private float lastHeight = 0;
	// Use this for initialization
	void Start () {
		AdJustSize ();
	}
	
	// Update is called once per frame
	void Update () {
		AdJustSize ();
	}

	void AdJustSize(){
		Camera cam = Camera.main;
		float wide = Screen.width;
		float high = Screen.height;
		if (lastWidth != wide || lastHeight != high) {
			lastWidth = wide;
			lastHeight = high;
			if (high * widthPerHeight > wide) {
				float targetHeight = wide / widthPerHeight;
				float margin = ((wide - targetHeight) / 2.0f / high);
				cam.rect = new Rect (0, margin, 1, 1 - margin * 2);
			} else {
				float targetWidth = high * widthPerHeight;
				float margin = ((wide - targetWidth) / 2.0f) / wide;
				cam.rect = new Rect (margin, 0, 1 - margin * 2, 1);
			}
		}
	}
}
