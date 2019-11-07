using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * This allows inventory items to be collected and displayed with a counter in the players 
 * inventory bar.
 */
public class Inventory : MonoBehaviour {
	public GameObject s1, s2, s3, s4, s5, s6;
	public Sprite empty;//empty slot image
	public GameObject message;//Message board to notifi the player when an item is collected
	private Sprite gemImg;
	private Dictionary<string, int> slot =  new Dictionary<string, int>();//Contains a description of the item and its position in the inventory
	private Dictionary<string, Sprite> imgDict = new Dictionary<string, Sprite> ();//Inventory icons
	private GameObject[] items = new GameObject[6];
	private int[] slotCounter = new int[6];
	private int counter;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		counter = 0;
		items[0] = s1;
		items[1] = s2;
		items[2] = s3;
		items[3] = s4;
		items [4] = s5;
		items [5] = s6;
		imgDict.Add ("axe", Resources.Load<Sprite> ("axe_artefactImg"));
		imgDict.Add ("sword", Resources.Load<Sprite> ("sword_artefactImg"));
		imgDict.Add ("staff", Resources.Load<Sprite> ("staff_artefactImg"));
		imgDict.Add ("lion", Resources.Load<Sprite> ("lion_artefactImg"));
		imgDict.Add ("magicCarpet", Resources.Load<Sprite> ("magicCarpet_artefactImg"));
		imgDict.Add ("horn", Resources.Load<Sprite> ("horn_artefactImg"));
		imgDict.Add ("mushroom", Resources.Load<Sprite> ("mushroom_artefactImg"));
		imgDict.Add ("runestone", Resources.Load<Sprite> ("runestone_artefactImg"));
		imgDict.Add ("arrow", Resources.Load<Sprite> ("arrowLogo"));
        imgDict.Add("key", Resources.Load<Sprite>("keyLevelOne"));
        imgDict.Add("doorHandle", Resources.Load<Sprite>("doorHandle"));
        if (gameObject.name == "erika_archer_bow_arrow") {
			incSlot ("arrow", 5);
		}

	}

	//Adds an item to the inventory if an instance was not already in the inventory
	public void addSlot(string key, int num=1){
		slot.Add (key, counter);
		slotCounter [counter] = num;
		items [counter].GetComponentInChildren<Text> ().text = ""+num;
		if (imgDict.ContainsKey(key)){
			items [counter].GetComponentInChildren<Image> ().sprite = imgDict[key];
		}
		if (key != "arrow") {
			coroutine = showMessage (key);
			StartCoroutine (coroutine);
		}
		++counter;
	}

	//Increments the count for an item in the inventory
	public void incSlot(string key, int num=1){
		if (num < 0) {
			decSlot (key, -1 * num);
		}else if (slot.ContainsKey (key)) {	
			int index = slot [key];
			slotCounter [index] = slotCounter [index] + num;
			items [index].GetComponentInChildren<Text> ().text = "" + slotCounter [index];
		} else {
			addSlot (key, num);
		}
	}

	//Decrements the count for an item, if count==0 the item is removed
	public void decSlot(string key, int num=1){
		if (slot.ContainsKey (key)) {
			int index = slot [key];
			slotCounter [index] = slotCounter [index] - num;
			if (slotCounter [index] <= 0) {
				slotCounter[index]=0;
			}
			items [index].GetComponentInChildren<Text> ().text = "" + slotCounter [index];
			if (slotCounter [index] <= 0 && key != "arrow") {
				removeSlot (key);
			} else if (slotCounter [index] <= 0 && key == "arrow") {
				coroutine = incArrow ();
				StartCoroutine (coroutine);
			}
		}
		Debug.Log ("dec");
	}

	//removes an item from the inventory
	public void removeSlot(string key){
		if (counter > 0) {
			--counter;
		}
		int index = slot [key];
		for (int i = index; i < 5; ++i) {
			GameObject nxt = items [i+1];
			GameObject curr = items [i];
			curr.GetComponentInChildren<Text> ().text = nxt.GetComponentInChildren<Text> ().text;
			curr.GetComponentInChildren<Image> ().sprite = nxt.GetComponentInChildren<Image> ().sprite;
		}
		items[5].GetComponentInChildren<Text> ().text="";
		items[5].GetComponentInChildren<Image> ().sprite = empty;
	}

	//returns number of items
	public int getCount(string key){
		int index = slot [key];
		return slotCounter [index];
	}

	//Displays message board to player for 3 seconds indicating what item they've found
	public IEnumerator showMessage(string key){
		Debug.Log ("Show message for " + key);
		message.SetActive (true);
		message.GetComponentInChildren<Text> ().text = ("You found " + key).ToUpper();
		yield return new WaitForSecondsRealtime (3f);
		message.SetActive (false);
	}

	public IEnumerator incArrow(){
		int counter = 0;
		while (getCount("arrow") < 5) {
			yield return new WaitForSecondsRealtime (10f);
			incSlot ("arrow", 1);
			++counter;
		}
	}
}
