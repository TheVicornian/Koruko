using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
 
    void Update()
    {
        this.gameObject.transform.Translate(0, 0, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().diamonds++;
            Destroy(this.gameObject);
        }
    }

}
    