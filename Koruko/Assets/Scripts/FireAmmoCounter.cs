using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAmmoCounter : MonoBehaviour
{
    public Text FireAmmoText;
    public PlayerMovement Player;
    public Image selectionHighlight;

    void Update()
    {
        FireAmmoText.text = Player.fireAmmo.ToString();
        selectionHighlight.enabled = Player.currentWeapon == 2;
    }


}






