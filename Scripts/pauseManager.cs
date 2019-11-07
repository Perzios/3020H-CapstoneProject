using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Contains scripts allowing the user to interact with the pause menu
 */
public class pauseManager : MonoBehaviour {
	public static bool paused = false;
	public Sprite muteImg, soundImg, musicImg, musicOffImg;
	private GameObject bgMusic;
	public Button soundBtn;
	public Button musicBtn;
    public GameObject tut,menu;

	void Start(){
		GameObject.Find ("BackgroundMusic");
		Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (tutorialInit.selection == 1)
        {
            menu.SetActive(false);
            tut.SetActive(true);
        }
        else {
            menu.SetActive(true);
            tut.SetActive(false);
        }        

        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {//If sound is on
            soundBtn.GetComponent<Image>().sprite = soundImg;
        }
        else
        {
            soundBtn.GetComponent<Image>().sprite = muteImg;
        }
        if (PlayerPrefs.GetInt("music", 1) == 1)
        {//If music is on
            musicBtn.GetComponent<Image>().sprite = musicImg;
        }
        else
        {
            musicBtn.GetComponent<Image>().sprite = musicOffImg;
        }
    }

	//Unpause game
	public void unpause(){
		paused = false;
		SceneManager.UnloadSceneAsync ("pauseMenu");
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    

	public void toMenu(){
		Debug.Log ("Menu");
		SceneManager.LoadScene ("mainMenu");
	}

	public void doExit(){
		Application.Quit ();
	}

	//Switch sound on/off
	public void toggleSound(){
		int sound = PlayerPrefs.GetInt ("sound", 1);
		PlayerPrefs.SetInt ("sound", Mathf.Abs (sound - 1));
		if (sound==0){
			soundBtn.GetComponent<Image>().sprite= soundImg;

		}else{
			soundBtn.GetComponent<Image>().sprite= muteImg;
		}
	}

	//Switch music on/off
	public void toggleMusic(){
		int music = PlayerPrefs.GetInt ("music", 1);
		PlayerPrefs.SetInt ("music", Mathf.Abs (music - 1));
		if (music==0){
			musicBtn.GetComponent<Image>().sprite= musicImg;
		}else{
			musicBtn.GetComponent<Image>().sprite= musicOffImg;
		}
	}

    public void tutorial() {
        menu.SetActive(false);
        tut.SetActive(true);
    }
}
