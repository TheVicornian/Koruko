using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreHandler : MonoBehaviour
{
   
    public Text DiamondText;
    public PlayerMovement Player;


    void Update()
    {
       DiamondText.text = Player.diamonds.ToString();
    }
}

       
    

