using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Draw crosshair on Persephone screen

public class Crosshair : MonoBehaviour
{

    [SerializeField]
    Texture2D image;

    [SerializeField]
    float crosshairSize;



    private void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) - (crosshairSize / 2), (Screen.height / 4) - (crosshairSize / 2) + (Screen.height / 14), crosshairSize, crosshairSize), image);
    }
}
