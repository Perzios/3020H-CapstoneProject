using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls all animations for Persephone

public class PlayerAnimation : MonoBehaviour
{

    Animator animator, bowAnim;

    bool eq = false, eq2 = false, loaded = false;
    public AudioClip StringPull, BowRelease;
    public AudioSource source;

    public GameObject bow;

    private PlayerAim m_PlayerAim;
    private PlayerAim PlayerAim
    {
        get
        {
            if (m_PlayerAim == null)
            {
                m_PlayerAim = GameManager.Instance.LocalPlayer.playerAim;
            }
            return m_PlayerAim;
        }
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        bowAnim = GameManager.Instance.InputController.bow.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
        animator.SetBool("isJump", GameManager.Instance.InputController.isJump);
        animator.SetBool("isAim", GameManager.Instance.InputController.isAim);
        animator.SetBool("isAtk", GameManager.Instance.InputController.isAtk);
        animator.SetBool("Shoot", GameManager.Instance.InputController.isShoot);
        animator.SetBool("isFall", GameManager.Instance.InputController.isFall);
        if (GameManager.Instance.InputController.weaponType == 2 || GameManager.Instance.InputController.weaponType == 0) {
           animator.SetBool("isEquip", GameManager.Instance.InputController.isEquip);
        }

        //Only animate bow if it is equiped
        if (bowAnim.gameObject.activeInHierarchy)
        {
            bowAnim.SetBool("Load", GameManager.Instance.InputController.isAim);
            if (GameManager.Instance.InputController.isAim && loaded == false)
            {
                loaded = true;
                source.PlayOneShot(StringPull);
            }
            bowAnim.SetBool("Fire", GameManager.Instance.InputController.isShoot);
            if (GameManager.Instance.InputController.isShoot)
            {
                StartCoroutine(wait());
                source.PlayOneShot(BowRelease);
            }
        }

        if (GameManager.Instance.InputController.isAtk == true )
        {
            animator.SetFloat("atk", Random.Range(1,3));
        }

        if (GameManager.Instance.InputController.Equip == true && eq == false && GameManager.Instance.InputController.isAim)
        {
            eq = true;
            animator.SetBool("isEquip", true);
            animator.SetFloat("Equip", -1.0f);
        }
        else if (GameManager.Instance.InputController.Equip == false && eq == true && !GameManager.Instance.InputController.isAim)
        {
            eq = false;
            animator.SetBool("isEquip", true);
            animator.SetFloat("Equip", 1.0f);
        }

        



        if (GameManager.Instance.InputController.isAim)
        {
            animator.SetFloat("AimAngle", PlayerAim.getAngle());
            if (GameManager.Instance.InputController.isShoot)
            {
                animator.SetFloat("isShoot", 0);
            }
        }
        else
        {
            animator.SetFloat("Equip", 0.0f);
            animator.SetFloat("AimAngle", 0.0f);
        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        loaded = false;
    }


}
