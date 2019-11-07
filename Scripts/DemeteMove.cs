using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates movement of demeter and determins if she is falling

public class DemeteMove : MonoBehaviour {

    Rigidbody rb;
    Vector3 jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2.0f, 0);
    }

    public void Move(Vector2 dir)
    {
        transform.position += (transform.forward * dir.x * Time.deltaTime +
            transform.right * dir.y * Time.deltaTime);
    }

    private void Update()
    {
        if (transform.GetComponent<Rigidbody>().position.y < -250)
        {
            transform.GetComponent<PlayerHP>().incHealth(-5000);
        }

        if (GameManager.Instance.InputController2.isGrounded == true && GameManager.Instance.InputController2.isJump)
        {
            rb.AddForce(Vector3.up * 200.0f, ForceMode.Impulse);            
            GameManager.Instance.InputController2.isGrounded = false;
            //transform.position += new Vector3(0,2.0f,0);
        }
        if (rb.velocity.y < -35)
        {
            GameManager.Instance.InputController2.isFall = true;
        }
        else
        {
            GameManager.Instance.InputController2.isFall = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        GameManager.Instance.InputController2.isGrounded = true;
    }
}
