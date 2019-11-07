using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

//Maintians players health
public class Health : MonoBehaviour {
	public float maxHealth;
	public float regeneration;
	public float current;
	private Vector3 spawnPoint;

    private int deaths = 0;


    //Increase/decrease current health levels
	public void incHealth(float health){
		current+=health;
		onHealthChange (current);
		if (current <= 0) {
			if (gameObject.tag == "Player") {
				current = maxHealth;
                deaths++;
				transform.position = spawnPoint;
			} else {
				Destroy (gameObject);
			}

            if (deaths == 9) {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameOver");
            }
		} else if (current > maxHealth) {
			current = maxHealth;
		}
	}
    void onHealthChange(float newHealth)
    {
        return;
    }

    public void setSpawnPoint(Vector3 pos)
    {
        spawnPoint = pos;
    }

   //return health
public float getHealth(){
		return current;
	}

	public void setHealth(float health){
		current = health;
	}

	void Start(){
		current = maxHealth;
		spawnPoint = transform.position;
		print (gameObject.name);
	}
}



