using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//uses a default UI slider to allow for progress.

public class ProgressSlider : MonoBehaviour
{
    public int type; //type, vertical or horizontal, 0 or 1
    public Slider slider; //slider should go from 0 to 100, translating to percent
    public Transform player;
    public Vector3 endPOS;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

       

        slider.value = calcProgress();



    }

    //this should determine the percentage DONE with the level
    //the closer the player is to the POS. type determines x or y
    float calcProgress()
    {
        float rawPercent = 0;
        if (type == 0) {
         rawPercent =  player.position.y / endPOS.y;
        }

        if(type == 1)
        {
         rawPercent =  player.position.x / endPOS.x;
        }

        float percent = rawPercent * 100;
        return percent;
    }



}
