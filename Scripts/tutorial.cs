using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls flow of the tutorial menu

public class tutorial : MonoBehaviour {

    private int count = 0;
    public GameObject tutOne, tutTwo , main;

	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next();
        }
	}

    void Next()
    {
        if (count == 0)
        {
            tutOne.SetActive(false);
            tutTwo.SetActive(true);
            count = 1;
        }else if(count == 1)
        {
            tutTwo.SetActive(false);
            tutOne.SetActive(true);
            count = 0;
        }       
    }

    public void exit()
    {
        main.SetActive(true);
        gameObject.SetActive(false);
    }
}
