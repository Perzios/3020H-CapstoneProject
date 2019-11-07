using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Displays a crosshair for Demeters magic

public class DemeterCroshair : MonoBehaviour {

    [SerializeField]
    Texture2D image;

    [SerializeField]
    float crosshairSize;



    private void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) - (crosshairSize / 2), Screen.height-(Screen.height / 4) - (crosshairSize / 2) , crosshairSize, crosshairSize), image);
    }
}
