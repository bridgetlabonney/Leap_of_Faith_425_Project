using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieMarc.Darkness;

public class candleCheckpoint : MonoBehaviour
{
    bool lighton;
    public bool crossed;
    public LightEmit candle;
    public Vector3 checkpointpos;
    IEnumerator turnLight()
    {
        candle.light_enabled = true;
        yield return new WaitForSecondsRealtime(7);
        candle.light_enabled = false;
    }

    void checkpoint()
    {
        //respawn pos = checkpoint pos
        crossed = true;
    }

    private void Update()
    {
        //if player presses F within hitbox, candle is off
        //check if boundary has been crossed 
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && lighton == false)
        {
            lighton = true;
            StartCoroutine(turnLight());
            if(!crossed) checkpoint();

        }
        lighton = false;
    }


}
