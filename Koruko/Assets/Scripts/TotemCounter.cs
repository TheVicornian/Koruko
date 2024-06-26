using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotemCounter : MonoBehaviour
{
    public Text totemText;
    public PlayerMovement Player;



    void Update()
    {
        totemText.text = Player.totem.ToString();

    }
 }

    
