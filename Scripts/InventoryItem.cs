using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This allows an item to be added to a players inventory, using the key as a indentifier.
 */
public class InventoryItem : MonoBehaviour {
	public string key;

	//Add item to player inventory
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			col.gameObject.GetComponent<Inventory> ().addSlot (key);
            artefacts.count++;
			Destroy (gameObject);
		}
	}
}
