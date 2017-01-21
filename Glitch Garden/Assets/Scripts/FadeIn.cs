using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour {
	public float fadeInTime;
	private Image fadePanel;
	private Color color;

	void Start() {
		fadePanel = GetComponent<Image>();
		color = Color.black;
	}

	void Update() {
		if(Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			color.a -= alphaChange;
			fadePanel.color = color;
		} else {
			gameObject.SetActive(false);
		}
	}
}
