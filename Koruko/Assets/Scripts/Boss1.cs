using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{

    public Animator anim;
    public Image BossHealthBar;
    
    //health
    int _hp = 80;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 80;

    private void Start()
    {
        anim.enabled = false;
        BossHealthBar.enabled = false;
    }

    void OnBecameVisible()
    { 
        anim.enabled = true;
        BossHealthBar.enabled = true;
    }
    private void Update()
    {
        BossHealthBar.enabled = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            if (hp > 1)
                hp--;
            else
                Destroy(this.gameObject);
        }

        if (other.tag == "FireProjectile")
        {
         
            Destroy(other.gameObject);
            if (hp > 1)
                hp--;
            else
                Destroy(this.gameObject);
        }

    }


}

