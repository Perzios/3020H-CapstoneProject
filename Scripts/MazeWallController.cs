using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves a maze wall when player stands on preasure plate

public class MazeWallController : MonoBehaviour
{
    public GameObject wallToOpen;
    
    public float x;
    
    public float z;
    public float movementSpeed = 1;

    private Vector3 endPosition; // = new Vector3(xpos, y, z);

    private Vector3 currentPos;


    bool open = false, close = true;

    private Animator animator;

    void Start()
    {
        currentPos = wallToOpen.transform.localPosition;
        endPosition = currentPos + new Vector3(x,0,z);
    }


    void Update()
    {
        

        if (open) {
            if (wallToOpen.transform.localPosition != endPosition)
                wallToOpen.transform.localPosition = Vector3.MoveTowards(wallToOpen.transform.localPosition, endPosition, movementSpeed * Time.deltaTime);
        }
        else {
            if (wallToOpen.transform.localPosition != currentPos)
                wallToOpen.transform.localPosition = Vector3.MoveTowards(wallToOpen.transform.localPosition, currentPos, movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale -= new Vector3(0, 0.2f, 0);
        collision.transform.position -= new Vector3(0, 0.2f, 0);
        open = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        transform.localScale += new Vector3(0, 0.2f, 0);
        collision.transform.position += new Vector3(0, 0.2f, 0);
        open = false;
    }

    
}
