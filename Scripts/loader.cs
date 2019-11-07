﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates image on load screen

public class loader : MonoBehaviour {

    private RectTransform rectComponent;
    private float rotateSpeed = -100f;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
