using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Manages arrows and firing arrows
public class Shooter : MonoBehaviour
{


    public Transform spawn, arrow, Marrow;
	private int numArrows = 0;
	private Inventory scoreBoard;
    private bool loaded = false;

	void Start(){
		scoreBoard = gameObject.GetComponent<Inventory> ();
	}

    // Update is called once per frame
    void Update()
    {
		scoreBoard.getCount ("arrow");
		if (scoreBoard.getCount("arrow") <= 0) {
            GameManager.Instance.InputController.arrowType = 1;
        }

        if (GameManager.Instance.InputController.isAim && (Time.time >= GameManager.Instance.InputController.nextTimeToFire) && loaded == false)
        {
			if (GameManager.Instance.InputController.arrowType == 0 && scoreBoard.getCount("arrow")>0) {
                Instantiate(arrow, spawn.position, spawn.rotation);
				if (scoreBoard.getCount("arrow") == 0) {
					GameManager.Instance.InputController.arrowType = 1;
				}
            } else if (GameManager.Instance.InputController.arrowType == 1) {
                Instantiate(Marrow, spawn.position, spawn.rotation);
            }
            
            loaded = true;
        }
		if (GameManager.Instance.InputController.isAim == false)
        {
            loaded = false;
        }
		if (GameManager.Instance.InputController.isShoot)
        {
            if (GameManager.Instance.InputController.arrowType == 0) {
				scoreBoard.decSlot("arrow",1);
				Debug.Log ("Arrow fired");
            }            
            StartCoroutine(load());
        }
        if(GameManager.Instance.InputController.isSwap) {
			
			if (GameManager.Instance.InputController.arrowType == 0 && scoreBoard.getCount("arrow")>0)
            {
				
                Instantiate(arrow, spawn.position, spawn.rotation);
            }
            else if (GameManager.Instance.InputController.arrowType == 1)
            {
                Instantiate(Marrow, spawn.position, spawn.rotation);
            }
        }
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(0.4f);
        loaded = false;
    }

	public void incArrow(int num){
		scoreBoard.incSlot ("arrow", num);
	}
}
