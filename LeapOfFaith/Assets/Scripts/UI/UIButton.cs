using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour
{
    //loads whatever scene matches the string name
   public void changeScene(string scene)
    {
        //this doesn't change anything other than fixing a pause menu bug :)
        Time.timeScale = 1;
        
        SceneManager.LoadScene(scene);
    }

    //quits the game
    public void quit()
    {
        Application.Quit();
    }

    
}
