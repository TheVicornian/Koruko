using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public PlayerMovement player;
    public Image shieldBar;

     void Update()
    {
        shieldBar.fillAmount = (float)player.shield / (float)player.maxSHIELD;
    }

}
