using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Updates player HP on their slider
//Inherits from Health

public class PlayerHP : Health
{

    public Slider healthBar;

    void Update()
    {
        healthBar.value = current / maxHealth * 100;
    }

}
