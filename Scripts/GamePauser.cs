using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pauses game

public class GamePauser : MonoBehaviour {

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = 0;
            SceneManager.LoadScene("pauseMenu" , LoadSceneMode.Additive);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
	}
}
