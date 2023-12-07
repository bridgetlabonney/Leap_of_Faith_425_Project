using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

   public int dmg;
   public int type = 0;
    // Start is called before the first frame update
    void Start()
    {
        //init type of obstacle
        switch(type)
        {
            case 0: //default: 0 dmg log (needs to be jumped over)
                dmg = 0;
                //load asset
                break;
            case 1: //spike
                dmg = 5;
                //load asset
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO
    //on colide with player
    //hitboxes

}
