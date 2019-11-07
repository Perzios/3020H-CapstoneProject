using UnityEngine;
using System.Collections;

//Rotates orb in random directions

public class Rotator : MonoBehaviour
{

    public float angularVelocity = 10.0f;
    public float speed;   // Rotation speed
    private Vector3 axisOfRotation;   // Rotation angle

    private void Start()
    {
        axisOfRotation = Random.onUnitSphere;
        speed = Random.Range(1f, 10f);
    }

    void Update()
    {
        transform.Rotate(axisOfRotation, angularVelocity * Time.smoothDeltaTime * speed);
    }
}
