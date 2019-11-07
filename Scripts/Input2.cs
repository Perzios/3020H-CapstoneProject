using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input for Demeter

public class Input2 : MonoBehaviour {

    public float Vertical, Horizontal , magicRate = 0.6f, atkspeed = 1.2f;
    public bool isJump ,isAim ,shot , isEquip , Equip = false, isAtk, isGrounded = true, isFall;
    public Vector2 Mouseinput;
    public volatile bool isShoot;
    public GameObject sword;

    public float nextTimeToFire = 1f;
    public float nextTimeToHit = 1f;

    private void Awake()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");
        sword.SetActive(false);
    }

    void Update () {
        Vertical = Input.GetAxis("LeftJoyVert");
        Horizontal = Input.GetAxis("LeftJoyHor");
        Mouseinput = new Vector2(Input.GetAxisRaw("RightJoyHor"), Input.GetAxisRaw("RightJoyVert"));

        if (isGrounded)
        {
            isJump = Input.GetButtonDown("A");
        }
        else {
            isJump = false;
        }

        if (Input.GetAxis("AimJoy") > 0.1f)
        {
            isAim = true;
        }
        else {
            isAim = false;
        }        

        if (!isAim)
        {
            isEquip = Input.GetButtonDown("Y");           
        }

        if (isEquip && Equip == false)
        {
            Equip = true;            
        }
        else if (isEquip && Equip == true)
        {
            Equip = false;
        }
        else if (isAim)
        {
            Equip = false;
        }

        if (Equip == false && isAim != true && Time.timeSinceLevelLoad > 1f)
        {
            StartCoroutine(Switcher(Equip));
        }
        else if (Equip)
        {
            StartCoroutine(Switcher(Equip));
        }

        if (isAim == false && Input.GetAxis("FireJoy") > 0.1f && Time.time >= nextTimeToHit + 0.1f && Equip ==true)
        {
            nextTimeToHit = Time.time + 1f / atkspeed;
            isAtk = true;
        }
        else
        {
            isAtk = false;
        }

        //magic
        if (shot)
        {
            nextTimeToFire = Time.time + 1f / magicRate;
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }

    IEnumerator Switcher(bool choose)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        sword.SetActive(choose);
    }
}
