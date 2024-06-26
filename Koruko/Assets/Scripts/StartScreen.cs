using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartScreen : MonoBehaviour
{
    public Animator Startscreen;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            
            Startscreen.SetTrigger("GOstart");
            Invoke("DelayLoad", 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            if (Application.isEditor)
                EditorApplication.isPlaying = false;
            else
            #endif
                Application.Quit();
        }
    }


    void DelayLoad()
    {
        SceneManager.LoadScene(1);
    }
}
        
    
