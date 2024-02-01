using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO
//health upgrades?
//enable/disable for cutscenes.
//array shenanigans (using GameObject[] h instead of 3)
//iframes

public class HUD : MonoBehaviour
{
    //controls health bar
    public GameObject[] h;
    private int numHearts; 
    public Player player;
    public Sprite empty;
    // Start is called before the first frame update
    void Start()
    {
        numHearts = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //check for new updates to player values
        healthConfig(player.health);
       
    }

    //numHearts tracks the NUMBER of hearts on screen
    //health tracks the players CURRENT health
    //if they dont match, player got hurt and health must be updated
    //since its so minimal, it can run every frame 
    void healthConfig(int health)
    {
        
        print(numHearts);
        print(player.health);
         if(health < numHearts)
        {
            // h1.GetComponent<UnityEngine.UI.Image>().sprite
            h[numHearts - 1].GetComponent<UnityEngine.UI.Image>().sprite = empty;

            numHearts = numHearts -  1;
        }
    }
}
