using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introscreen : MonoBehaviour
{
   public Animator Startscreen;
   public int loadLevel = 3;

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.Space) || Input.GetButton("Continue"))
            {

                Startscreen.SetTrigger("GOstart");
                Invoke("DelayLoad", 1.5f);
            }

 
        }


        void DelayLoad()
        {
         SceneManager.LoadScene(loadLevel);
        }   
}
