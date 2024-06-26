using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public float speed = 0.025f;
    public float timer = 2;

    void Start()
    {

        flip();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void flip()
    {
        speed = speed * -1;

        Invoke("flip", timer);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

    }

    void OnCollisionExit2D (Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
