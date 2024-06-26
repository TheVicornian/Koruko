using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerMovement player;
    public Image hpBar;

    private void Update()
    {
        hpBar.fillAmount = (float)player.hp / (float)player.maxHP;
    }
}
