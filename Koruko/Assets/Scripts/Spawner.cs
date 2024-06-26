using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int min = 60;
    public int max = 120;
    public float itemDuration = 10f; // Duration in seconds before the item is destroyed

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(min, max));
    }

    void Spawn()
    {
        GameObject item = Instantiate(items[Random.Range(0, items.Length)], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
        Destroy(item, itemDuration); // Destroy the spawned item after itemDuration seconds
        Invoke("Spawn", Random.Range(min, max));
    }
}