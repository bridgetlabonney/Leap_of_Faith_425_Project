using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO
//change game over screen to make this script design work
public class checkpointManager : MonoBehaviour
{
    public Vector3 respawnpos;
    public HUD hud;
    public Player p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkpoint(Vector3 pos)
    {
        respawnpos = pos;
    }

    void respawn()
    {
        //place character at respawnpos
        if(hud.checkDeath())
        {
           //confirm player has hit "continue"
          
        }
    }
}
