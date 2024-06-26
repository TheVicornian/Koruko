using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform2 : MonoBehaviour
{
    public float speedX = 0.025f;
    public float speedY = 0.025f;
    public float timer = 2;

    void Start()
    {

        flip();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    void flip()
    {
        speedX = speedX * -1;
        speedY = speedY * -1;

        Invoke("flip", timer);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
      collision.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
      collision.transform.SetParent(null);
    }
}
