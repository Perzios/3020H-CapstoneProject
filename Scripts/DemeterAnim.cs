using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls all animations of Demeter

public class DemeterAnim : MonoBehaviour {

    Animator animator;

    bool eq = false;

    private PlayerAim m_PlayerAim;
    private PlayerAim PlayerAim
    {
        get
        {
            if (m_PlayerAim == null)
            {
                m_PlayerAim = GameManager.Instance.LocalPlayer2.playerAim;
            }
            return m_PlayerAim;
        }
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update () {
        animator.SetFloat("Ver", GameManager.Instance.InputController2.Vertical);
        animator.SetFloat("Hor", GameManager.Instance.InputController2.Horizontal);
        animator.SetBool("isJump", GameManager.Instance.InputController2.isJump);
        animator.SetBool("isAim", GameManager.Instance.InputController2.isAim);
        animator.SetBool("isAtk", GameManager.Instance.InputController2.isAtk);
        animator.SetBool("isFall", GameManager.Instance.InputController2.isFall);

        if (GameManager.Instance.InputController2.isAim)
        {
            animator.SetFloat("aimAngle", PlayerAim.getAngle());
            animator.SetBool("MagicAtk", GameManager.Instance.InputController2.isShoot);
        }
        else
        {
            animator.SetBool("MagicAtk", false);
            animator.SetFloat("aimAngle", 0.0f);
        }

        if (GameManager.Instance.InputController2.isAtk == true)
        {
            animator.SetFloat("atk", Random.Range(1, 3));
        }

        if (GameManager.Instance.InputController2.Equip == true && eq == false && !GameManager.Instance.InputController2.isAim)
        {
            eq = true;
            animator.SetBool("SwordOn", true);
        }
        else if (GameManager.Instance.InputController2.Equip == false && eq == true && !GameManager.Instance.InputController2.isAim)
        {
            eq = false;
            animator.SetBool("Swordoff", true);
        }
        else {
            animator.SetBool("SwordOn", false);
            animator.SetBool("Swordoff", false);
        }
    }
}
