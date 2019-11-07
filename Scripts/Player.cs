using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls all persephone by updating the movement script and ensuring correct rotation

[RequireComponent(typeof(MoveController))]

public class Player : MonoBehaviour
{
    public int count = 0;
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

    public GameObject target;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = GetComponent<MoveController>();
            }
            return m_MoveController;
        }
    }

    private Crosshair m_Crosshair;
    public Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
            {
                m_Crosshair = GetComponentInChildren<Crosshair>();
            }
            return m_Crosshair;
        }
    }

    InputController playerInput;

    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float moveSpeed = runSpeed;

        if (playerInput.isAim)
        {
            moveSpeed = Aimspeed;
        }

        mouseI = GameManager.Instance.InputController.Mouseinput;

        Vector2 dir = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        MoveController.Move(dir);

        playerAim.setRotation(mouseI.y * MouseControl.Sensitivity.y);



        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }


    //opens the tutorial screen when the players find each other
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Demeter")
        {
            count++;
            if (count == 1) {
                Time.timeScale = 0;
                tutorialInit.selection = count;
                SceneManager.LoadScene("pauseMenu", LoadSceneMode.Additive);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }
    public int GetCount() {
        return count;
    }
}
