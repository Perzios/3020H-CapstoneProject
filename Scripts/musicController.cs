using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the background music
 */
public class musicController : MonoBehaviour {
	private IEnumerator coroutine;
	//Determines if it should start playing background music
	void Start () {
		if (PlayerPrefs.GetInt ("music", 1) == 1) {
			GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().Play();
		} else {
			GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().Pause();

		}
		coroutine = checkStatus();
		StartCoroutine(coroutine);

	}

	public void playMusic(bool play){
		GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().enabled = play;

	}

	//Checks if prefs updated every 2 seconds
	private IEnumerator checkStatus(){
		while (true) {
			yield return new WaitForSeconds (2);
			if (PlayerPrefs.GetInt ("music", 1) == 1) {
				if (!GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().isPlaying) {
					GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().Play ();
				}
			} else {
				if (GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().isPlaying) {
					GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().Pause ();
				}

			}
		}
	}
}
