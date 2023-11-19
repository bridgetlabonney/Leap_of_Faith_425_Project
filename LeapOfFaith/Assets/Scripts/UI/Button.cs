using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
   void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void quit()
    {
        Application.Quit();
    }
}
