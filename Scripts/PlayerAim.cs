using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates angle at which player is aiming

public class PlayerAim : MonoBehaviour
{

    public void setRotation(float amount)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x - amount, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public float getAngle()
    {
        return checkAngle(transform.eulerAngles.x);
    }

    public float checkAngle(float val)
    {
        float angle = val - 180;
        if (angle > 0)
        {
            return angle - 180;
        }
        return angle + 180;
    }


}
