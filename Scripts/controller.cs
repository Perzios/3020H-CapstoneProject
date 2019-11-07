using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control camera movement for players

public class controller : MonoBehaviour {

    private const float Y_ANGLE_MIN = 6.0f;
    private const float Y_ANGLE_MAX = 40.0f;

    public Transform lookAt;
    public Transform player;

    public float dist = 8;
    public float currentX = 0.0f;
    public float currentY = 20.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Update()
    {
        if (lookAt.transform.parent.name == "Demeter")
        {
            currentX += Input.GetAxis("RightJoyHor") * sensitivityX;
            currentY -= Input.GetAxis("RightJoyVert") * sensitivityY;
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            dist = Mathf.Clamp(dist, 5.0f, 12.0f);
        }
        else
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
            dist -= Input.GetAxis("Mouse ScrollWheel");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            dist = Mathf.Clamp(dist, 5.0f, 12.0f);
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -dist);
        Quaternion rot;
        rot = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rot * dir;

        Vector3 frompos = lookAt.transform.position;
        Vector3 toPos = transform.position;
        Vector3 direction = toPos - frompos;
        RaycastHit hit;
        if (Physics.SphereCast(lookAt.transform.position, 0.1f, direction, out hit, dist))
        {
            if (hit.transform.tag != "spawn") {
                Debug.DrawRay(lookAt.transform.position, direction, Color.green, 5000);
                transform.position = hit.point;
            }
            
        }
        transform.LookAt(lookAt.position);
        var CharacterRot = transform.rotation;
        CharacterRot.x = 0;
        CharacterRot.z = 0;
        player.rotation = CharacterRot;
    }

}
