using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for all input of Persephone

public class InputController : MonoBehaviour
{

    public float Vertical, Horizontal, Shoot, rate = 0.6f, atkspeed = 1.2f ;
    public Vector2 Mouseinput;
    public bool isJump , isGrounded = true , isFall;
    public bool isAim;
    public bool Equip = false, isEquip, isSwap ,isAtk;
    public volatile bool isShoot;
    public GameObject bow, backBow, spawn , dagger;
    public int arrowType = 0 , weaponType = 0;

    public float nextTimeToFire = 1f;
    public float nextTimeToHit = 1f;
    public float nextTimeToJump = 1f;

    private void Awake()
    {
        bow = GameObject.FindGameObjectWithTag("Bow");
        spawn = GameObject.FindGameObjectWithTag("Launch");
        dagger = GameObject.FindGameObjectWithTag("dagger");
        dagger.SetActive(false);
        bow.SetActive(false);

        backBow = GameObject.FindGameObjectWithTag("Back");
        backBow.SetActive(true);
    }    

    void Update()
    {
        
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Mouseinput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Debug.Log(Time.time);
        if (isGrounded)
        {
            isJump = Input.GetButtonDown("Jump");
        }
        else
        {
            isJump = false;
        }


        isAim = Input.GetButton("Fire2");
        isSwap = Input.GetButtonUp("arrow");        

        if (isSwap) {
            arrowType = (arrowType + 1) % 2;
        }

        if (!isAim)
        {
            isEquip = Input.GetButtonDown("Equip");
            if (isEquip) {
                weaponType++;
                if (weaponType >= 3)
                {
                    weaponType = 0;
                }
                if (weaponType == 1)
                {
                    dagger.SetActive(true);
                }
                else {
                    dagger.SetActive(false);
                }
            }
        }

        if (isEquip && Equip == false && weaponType == 2)
        {
            Equip = true;            
        }
        else if (isEquip && Equip == true && weaponType == 0)
        {
            Equip = false;            
        }
        else if (isAim)
        {
            Equip = true;
            weaponType = 2;
        }

        if (Equip == false && isAim != true && weaponType == 0 && Time.timeSinceLevelLoad > 0.1f)
        {
            StartCoroutine(Switcher(Equip));
        }
        else if (Equip == true && weaponType == 2)
        {
            StartCoroutine(Switcher(Equip));
        }

        if (isAim == false  && Input.GetButtonUp("Fire1") && Time.time >= nextTimeToHit + 0.1f && weaponType == 1)
        {
            nextTimeToHit = Time.time + 1f / atkspeed;
            isAtk = true;
        }
        else {
            isAtk = false;
        }




        if (isAim && Input.GetButtonUp("Fire1") && Time.time >= nextTimeToFire + 0.1f)
        {
            nextTimeToFire = Time.time + 1f / rate;
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
        bow.SetActive(choose);
        backBow.SetActive(!choose);
    }
}
