using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text AmmoText;
    public PlayerMovement Player;
    public Image selectionHighlight;

    void Update()
    {
        AmmoText.text = Player.ammo.ToString();
        selectionHighlight.enabled = Player.currentWeapon == 1;
    }
}
