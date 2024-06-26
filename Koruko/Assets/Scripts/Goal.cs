using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject endLevel;
    public int loadLevel = 4;
 //load next level
    void OnTriggerEnter2D (Collider2D other)                                             
    {
        if (other.tag == "Player")
            
            SceneManager.LoadScene(loadLevel);
    }

}

