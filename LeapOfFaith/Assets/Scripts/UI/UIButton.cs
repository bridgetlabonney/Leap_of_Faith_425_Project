using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour
{
    //loads whatever scene matches the string name
   public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //quits the game
    public void quit()
    {
        Application.Quit();
    }
}
