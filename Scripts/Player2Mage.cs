using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls all Demeter by updating the movement script and ensuring correct rotation

[RequireComponent(typeof(DemeteMove))]

public class Player2Mage : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    Vector2 mouseI;

    [SerializeField]
    float runSpeed;
    [SerializeField]
    float Aimspeed;
    [SerializeField]
    MouseInput MouseControl;

    public PlayerAim playerAim;

    private DemeteMove m_MoveController;
    public DemeteMove MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = GetComponent<DemeteMove>();
            }
            return m_MoveController;
        }
    }

    Input2 playerInput;

    void Awake()
    {
        playerInput = GameManager.Instance.InputController2;
        GameManager.Instance.LocalPlayer2 = this;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        float moveSpeed = runSpeed;

        mouseI = GameManager.Instance.InputController2.Mouseinput;

        Vector2 dir = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        MoveController.Move(dir);
        playerAim.setRotation(mouseI.y * MouseControl.Sensitivity.y);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
