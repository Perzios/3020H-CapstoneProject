using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls third person camera for a player

public class ThirdPersonCam : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 6.0f;
    private const float Y_ANGLE_MAX = 40.0f;

    public Transform lookAt;
    public Transform camTransform;
    public Transform player;

    public float dist;
    public float currentX = 0.0f;
    public float currentY = 20.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
    }        

    private void LateUpdate()
    {

        camTransform.LookAt(lookAt.position);
    }
}
