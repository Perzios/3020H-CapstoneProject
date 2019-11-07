using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves two maze walls when player stands on preasure plate

public class mazeTwoWallController : MonoBehaviour {

    public GameObject wall1;
    public GameObject wall2;
    public float x1;
    public float x2;
    public float z1;
    public float z2;
    public float movementSpeed = 1;

    private Vector3 endPosition1;
    private Vector3 endPosition2;

    private Vector3 currentPos1;
    private Vector3 currentPos2;


    bool open = false, close = true;

   

    void Start()
    {
        currentPos1 = wall1.transform.localPosition;
        currentPos2 = wall2.transform.localPosition;
        endPosition1 = currentPos1 +  new Vector3(x1,0, z1);
        endPosition2 = currentPos2 + new Vector3(x2, 0, z2);
    }


    void Update()
    {
        

        if (open)
        {
            if (wall1.transform.localPosition != endPosition1)
                wall1.transform.localPosition = Vector3.MoveTowards(wall1.transform.localPosition, endPosition1, movementSpeed * Time.deltaTime);

            if (wall2.transform.localPosition != endPosition2)
                wall2.transform.localPosition = Vector3.MoveTowards(wall2.transform.localPosition, endPosition2, movementSpeed * Time.deltaTime);

        }
        else
        {
            if (wall1.transform.localPosition != currentPos1)
                wall1.transform.localPosition = Vector3.MoveTowards(wall1.transform.localPosition, currentPos1, movementSpeed * Time.deltaTime);

            if (wall2.transform.localPosition != currentPos2)
                wall2.transform.localPosition = Vector3.MoveTowards(wall2.transform.localPosition, currentPos2, movementSpeed * Time.deltaTime);

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
