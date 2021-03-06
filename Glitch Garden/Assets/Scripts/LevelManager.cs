﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() {
		if(autoLoadNextLevelAfter != 0) {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
