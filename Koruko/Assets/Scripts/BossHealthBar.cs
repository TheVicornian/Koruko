using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Boss1 boss; // Reference to the boss controller script
    public Image hpBar; // Reference to the health bar image

    void Update()
    {
        // Update the fill amount of the health bar based on the boss's current health
        hpBar.fillAmount = (float)boss.hp / (float)boss.maxHP;
    }


}
