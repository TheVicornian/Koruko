using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzsawSpawner : MonoBehaviour
{
    public int min = 60;
    public int max = 120;
    
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(min, max));
    }

    void Spawn()
    {
        GameObject item = Instantiate(items[0], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
        Instantiate(items[1], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
        Invoke("Spawn", Random.Range(min, max));
    }
}

