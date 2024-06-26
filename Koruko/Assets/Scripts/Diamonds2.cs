using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0, 0, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().diamonds = +5;
            Destroy(this.gameObject);
        }
    }
}
