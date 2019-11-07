using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds force to arrow when player shoots and contoles arrow drop

public class ArrowSpawn : MonoBehaviour
{

    bool fired = false , Drop = false;

    Rigidbody rb;
    ParticleSystem ps;

    void Awake()
    {
        gameObject.transform.GetComponent<Embed>().enabled = false;
        rb = gameObject.transform.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (GameManager.Instance.InputController.isShoot && !fired)
        {
            fired = true;
            gameObject.transform.GetComponent<Embed>().enabled = true;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(Vector3.forward * 2000f);
            StartCoroutine(dropper());
        }

        if (GameManager.Instance.InputController.isSwap) {
            Destroy(gameObject);
        }
        if (Drop == true) {
            arrowDrop();
        }
        
    }

    void arrowDrop()
    {
        float yVelocity = rb.velocity.y;
        float zVelocity = rb.velocity.z;
        float xVelocity = rb.velocity.x;
        float comVelocity = Mathf.Sqrt(xVelocity * xVelocity + zVelocity * zVelocity);
        float fallAngle = -1 * Mathf.Atan2(yVelocity, comVelocity) * 180 / Mathf.PI;

        transform.eulerAngles = new Vector3(fallAngle, transform.eulerAngles.y, transform.eulerAngles.x);
    }



    private void LateUpdate()
    {
        //Reposition to correct location on bow if the arrow has not yet been fired
        if (!fired)
        {
            transform.SetPositionAndRotation(GameManager.Instance.InputController.spawn.transform.position, GameManager.Instance.InputController.spawn.transform.rotation);
        }
        //Destroys arrow if player exits aim mode
        if (GameManager.Instance.InputController.isAim == false && fired == false)
        {
            Destroy(gameObject, 0.01f);
        }

    }

    IEnumerator dropper()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        Drop = true;
    }
}
