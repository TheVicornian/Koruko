using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        if (Input.GetButton("Continue"))
        {
            Debug.Log("Resatart button pressed");
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

    }
    
    
}
