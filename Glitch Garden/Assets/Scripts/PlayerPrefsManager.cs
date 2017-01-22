using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat(OptionKeys.MASTER_VOLUME_KEY.ToString());
	}

	public static void SetMasterVolume(float volume) {
		if(volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(OptionKeys.MASTER_VOLUME_KEY.ToString(), volume);
		} else {
			Debug.Log("Invalid volume settings");
		}
	}

	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat(OptionKeys.DIFFICULTY_KEY.ToString());
	}

	public static void SetDifficulty(float difficulty) {
		if(difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(OptionKeys.DIFFICULTY_KEY.ToString(), difficulty);
		} else {
			Debug.Log("Invalid volume settings");
		}
	}



}
