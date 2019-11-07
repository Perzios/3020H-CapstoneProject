using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates spawn [oint of player. This is where they will spawn after they die

public class checkPoint : MonoBehaviour {

    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHP>().setSpawnPoint(collision.transform.position);
        }
    }
}
