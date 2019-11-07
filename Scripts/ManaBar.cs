using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Displays and manages players mana
 */
public class ManaBar : MonoBehaviour {
	public Slider manaBar;
	public float rate;
	private float value;

	// Use this for initialization
	void Start () {
		value = 100;
        updateBar();
	}
	
	// Update is called once per frame
	void Update () {
        value = manaBar.value;
		if (value != 100) {
			value += rate;
            if (value > 100) {
                value = 100;
            }
			updateBar ();
		}
	}

	//Update value displayed on mana bar
	void updateBar(){
		manaBar.value = value;
	}

	//Change mana amount
	void incMana(float amount){
		value += amount;
	}

    float getMana() {
        return value;
    }

}
