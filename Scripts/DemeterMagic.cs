using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Controls Demeters magic and its actions.
 */
public class DemeterMagic : MonoBehaviour {

    public Transform explode, spawn;
    public GameObject pEffect1, pEffect2, gate , wind , crate,button , fire1, fire2 ,tut;
    public int skullCount = 0;
    public AudioSource dungeonDoor;
    public ParticleSystem hitPlat;
    public ParticleSystem explosion;
    public AudioSource breakLatern;
    public ParticleSystem rock;
    public static bool water = false;
    public Slider manaBar;

    private int waterCount = 0;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.InputController2.isAim && manaBar.value>=15.0f && (Time.time >= GameManager.Instance.InputController2.nextTimeToFire) && Input.GetAxis("FireJoy") > 0.5f)
        {
           
            RaycastHit hit;
            if (Physics.SphereCast(spawn.transform.position, 0.1f, spawn.transform.forward, out hit, 25f))
            {
                manaBar.value -= 15.0f;
                //Debug.Log(manaBar.value);
                //Debug.DrawRay(spawn.transform.position, spawn.transform.forward, Color.green, 50);
                GameManager.Instance.InputController2.shot = true;
                StartCoroutine(MagicExplode(hit));
                //Instantiate(explode, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.collider.gameObject.CompareTag("Lantern"))
                {
                    breakLatern.Play();
                    Destroy(hit.collider.gameObject);
                    crate.SetActive(true);                  
                    EnableFlame.LightOn = true;
                }
                if (hit.transform.tag == "TutDoor") {
                    Destroy(tut);
                }
                if (hit.transform.tag == "blueball")
                {
                    hit.transform.GetComponent<floorGate>().openThegate();
                }
                if (hit.transform.tag == "purpleball")
                {
                    hit.transform.GetComponent<purpleOrb>().openThegate();
                }
                if (hit.collider.gameObject.CompareTag("DungeonDoor"))
                {
                    dungeonDoor.Play();
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.CompareTag("magicRock") && removeGate.gateOpen)
                {
                    StartCoroutine("magicRock");
                    Destroy(gate);
                }
                if (hit.collider.gameObject.CompareTag("PlatformSkull") && risePlatform.DemOnPlat == true)
                {
                    skullCount++;
                    hitPlat.Play();
                    if (skullCount == 1) {
                        Destroy(fire1);
                    }
                    else if (skullCount == 2) {
                        Destroy(fire2);
                    }
                    else if (skullCount == 3)
                    {
                        explosion.Play();
                        Destroy(hit.collider.gameObject);                        
                        DisableColliders.block = false;
                    }
                }
                if (hit.collider.gameObject.CompareTag("nonRiddleItem"))
                {
                    transform.GetComponentInChildren<PlayerHP>().incHealth(-8);
                }
                if (hit.collider.gameObject.CompareTag("riddleItem"))
                {
                    hit.collider.GetComponent<riddleObject>().demeterDestroy();
                    //riddleObject.destroyRiddleObject = true;
                }
                if (hit.collider.gameObject.CompareTag("cage") && water == true)
                {
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.CompareTag("waterBox"))
                {
                    Destroy(hit.transform.gameObject);
                    waterCount++;
                    if (waterCount == 2)
                    {
                        water = true;
                        button.SetActive(true);
                    }
                }

            }
        }
        else if (GameManager.Instance.InputController2.isAim && manaBar.value >= 25.0f && (Time.time >= GameManager.Instance.InputController2.nextTimeToFire) && Input.GetButtonUp("X"))
        {
            RaycastHit hit;
            if (Physics.SphereCast(spawn.transform.position, 0.1f, spawn.transform.forward, out hit, 25f))
            {
                GameManager.Instance.InputController2.shot = true;
                manaBar.value -= 25.0f;
                StartCoroutine(MagicWind(hit));

                
            }
        }
        else
        {
            GameManager.Instance.InputController2.shot = false;
        }
    }

    IEnumerator MagicExplode(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(explode, hit.point, Quaternion.LookRotation(hit.normal));        
        GetComponent<AudioSource>().Play();
    }

    IEnumerator MagicWind(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(wind, hit.point, Quaternion.LookRotation(hit.normal));
    }

    IEnumerator magicRock()
    {
        pEffect1.SetActive(false);
        rock.Play();
        yield return new WaitForSeconds(4.8f);
        pEffect2.SetActive(true);
    }
}
