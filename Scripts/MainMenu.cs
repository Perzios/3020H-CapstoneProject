using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//All menu button functions and loading screen functions

public class MainMenu : MonoBehaviour {
    public Canvas mainMenu;
    public GameObject instrMenu , instrPanel;
    public GameObject settingMenu;
    public Button soundBtn;
    private Text soundBtnText ;
    public Button musicBtn;
    private Text musicBtnText;
    public Sprite muteImg, soundImg, musicImg, musicOffImg;
    public GameObject loadScreen;
    public Text  TipsField;
    public bool changing = false;
    public GameObject audio;

    int prev , next;

    AsyncOperation operation;


    public void OnStart() {
        if (PlayerPrefs.GetInt("sound", 1) == 1) {//If sound is on
            soundBtn.GetComponent<Image>().sprite = soundImg;
        } else {
            soundBtn.GetComponent<Image>().sprite = muteImg;
        }
        if (PlayerPrefs.GetInt("music", 1) == 1) {//If music is on
            musicBtn.GetComponent<Image>().sprite = musicImg;
        } else {
            musicBtn.GetComponent<Image>().sprite = musicOffImg;
        }
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        operation = SceneManager.LoadSceneAsync("levelone");   //Start loading first level while in main menu
        operation.allowSceneActivation = false;
        instrMenu.SetActive(false);
        settingMenu.SetActive(false);
        next = Random.Range(0, tips.Length);
        prev = next;
        TipsField.text = tips[next];
    }

    public void onPlay() {  //Play button
        Debug.Log("Play");
        //operation.allowSceneActivation = true;
        StartCoroutine(loadAsync());

    }

    IEnumerator loadAsync() {
        operation.allowSceneActivation = true;
        while (!operation.isDone) {

            loadScreen.SetActive(true);
            float progress = Mathf.Clamp01((operation.progress / 0.9f));

            yield return null;
        }
    }

    private bool gameLoaded() {
        for (int i = 0; i < SceneManager.sceneCount; ++i) {
            print(SceneManager.GetSceneAt(i).name);
            if (SceneManager.GetSceneAt(i).name == "levelone") {
                return true;
            }
        }
        return false;
    }

    public void onSettigns() { //Settings button
        Debug.Log("Settings");
        settingMenu.SetActive(true);
        mainMenu.enabled = false;
        instrMenu.SetActive(false);
    }

    public void onInstructions() { //Intructions button
        Debug.Log("Instructions");
        
        instrMenu.SetActive(true);
        mainMenu.enabled = false;
        settingMenu.SetActive(false);

    }

    public void onMain() { //Back to main menu
        mainMenu.enabled = true;
        instrMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void toggleSound() { //sound button
        int sound = PlayerPrefs.GetInt("sound", 1);
        PlayerPrefs.SetInt("sound", Mathf.Abs(sound - 1));
        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {//If sound is on
            soundBtn.GetComponent<Image>().sprite = soundImg;
        }
        else
        {
            soundBtn.GetComponent<Image>().sprite = muteImg;
        }
    }

    public void toggleMusic() { //music button
        int sound = PlayerPrefs.GetInt("music", 1);
        PlayerPrefs.SetInt("music", Mathf.Abs(sound - 1));
        if (PlayerPrefs.GetInt("music", 1) == 1)
        {//If music is on
            musicBtn.GetComponent<Image>().sprite = musicImg;
            audio.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            musicBtn.GetComponent<Image>().sprite = musicOffImg;
            audio.GetComponent<AudioSource>().enabled = false;
        }
    }

    public void onExit() { //Quit game button
        Application.Quit();
    }

    IEnumerator changeTip(float t, Text i) { //Changes load screen tip text
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        next = Random.Range(0, tips.Length);
        while (prev == next) {
            next = Random.Range(0, tips.Length);
        }
        prev = next;
        TipsField.text = tips[Random.Range(0, tips.Length)];

        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        changing = false;
    } 

    private void Update()
    {
        if (Time.realtimeSinceStartup % 6 < 1) {
            if (changing == false) {
                StartCoroutine(changeTip(1.0f, TipsField));
                changing = true;
            }
            
        }
    }
    //tips
    private string[] tips = {" Don’t be a hero", "Avoid all guards on duty", "Do not waste your arrows", "Use your magic wisely", "Play to your strengths", "Keep track of your health", "Do not pick up health if you have enough", "Don’t fall off platforms", "Stay aware of your surroundings", "Just keep moving", "Tooltip missing", "If you’re losing health, something is probably attacking you", "Don’t stray from your partner", "If your health depletes you will die "};

}

