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

    public void restartFromCheckpoint()
    {
        //get player's current checkpointpos
        //may have to play with cameras
        //set player's current position to checkpointpos

    }
}
