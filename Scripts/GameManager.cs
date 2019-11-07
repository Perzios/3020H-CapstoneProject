using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Global way of accessing input scripts for both players

public class GameManager
{

    public event System.Action<Player> OnLocalPlayerJoined;
    public event System.Action<Player2Mage> OnLocalPlayerJoined2;

    private GameObject gObject;

    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gObject = new GameObject("_gameManager");
                m_Instance.gObject.AddComponent<InputController>();
                m_Instance.gObject.AddComponent<Input2>();
            }
            return m_Instance;
        }
    }

    //Allow access to InputController values
    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
            {
                m_InputController = gObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private Input2 m_InputController2;
    public Input2 InputController2
    {
        get
        {
            if (m_InputController2 == null)
            {
                m_InputController2 = gObject.GetComponent<Input2>();
            }
            return m_InputController2;
        }
    }

    //Allow access to LocalPlayer values
    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if (OnLocalPlayerJoined != null)
            {
                OnLocalPlayerJoined(m_LocalPlayer);
            }
        }
    }

    private Player2Mage m_LocalPlayer2;
    public Player2Mage LocalPlayer2
    {
        get
        {
            return m_LocalPlayer2;
        }
        set
        {
            m_LocalPlayer2 = value;
            if (OnLocalPlayerJoined2 != null)
            {
                OnLocalPlayerJoined2(m_LocalPlayer2);
            }
        }
    }

}
