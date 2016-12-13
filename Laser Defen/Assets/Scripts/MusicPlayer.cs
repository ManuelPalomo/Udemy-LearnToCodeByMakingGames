using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;

	private AudioSource music;

	void Awake() {
		if(instance != null && instance != this) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
		}

	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		music.Stop();
		if(scene.name == "Start") {
			music.clip = startClip;
		} else {
			music.clip = gameClip;
		}
		music.Play();
		
	}
}
