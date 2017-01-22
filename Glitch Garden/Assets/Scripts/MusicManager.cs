using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] musicInLevel;

	private AudioSource audioSource;

	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		audioSource = GetComponent<AudioSource>();
		int level = scene.buildIndex;
		if(musicInLevel[level] != null) {
			audioSource.clip = musicInLevel[level];
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
}
