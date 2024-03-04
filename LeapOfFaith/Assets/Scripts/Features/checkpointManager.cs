using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO
//change game over screen to make this script design work

/// <summary>
/// Here's how the checkpoint system works
/// 1. The HUD constantly checks for death with a public boolean.
/// 2. once the boolean turns true, GameOver.cs activates, pauses the game and displays the game over screen.
/// 3. CheckpointUI.cs references this script to allow it to respawn the player at their checkpoint. it's attached to buttons only when needed
/// to avoid extra work. it uses the public respawn().
/// 
/// 
/// To make a checkpoint work:
/// 
/// 1. Load the new CONTROL MODULE prefab in prefabs, where the scripts are already attached to each other: 
/// you just need to attach Player and Camera.
/// 2. Put your checkpoints whereever you want, their POS will update on start.
/// 3. Attach CONTROL MODULE to the checkpoint
/// 4. Attach lightEmit script
/// 5. You're done! :)
/// 
/// </summary>
public class checkpointManager : MonoBehaviour
{
    public Vector3 respawnpos;
    public HUD hud;
    public bool continued = false, hasPOS = false;
    public GameObject p;
    public Player pl;
   
   
    // Start is called before the first frame update
    void Start()
    {
        respawnpos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkpoint(Vector3 pos)
    {
        respawnpos = pos;
        hasPOS = true;
    }

    //this dpesn't nessecarily need to reset puzzle progress - and might be more fair if it didnt! but i thought it would be a good note to add.
    public void respawn()
    {
        //place character at respawnpos
        
           
            p.transform.position = respawnpos;
        hud.dead = false;
        hud.resetHUD();
            pl.health = 3;
           Time.timeScale = 1;
    

        
    }
}
