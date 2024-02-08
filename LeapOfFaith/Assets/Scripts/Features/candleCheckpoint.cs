using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieMarc.Darkness;

public class candleCheckpoint : MonoBehaviour
{
    public Vector3 checkpointpos;
    public LightEmit candle;
    bool crossed;
    void turnLight(bool t)
    {
        candle.light_enabled = t;
    }

    void checkpoint()
    {
        //if player crosses boundary AND has not been crossed before
        turnLight(true);
        //respawn pos = checkpoint pos
        crossed = true;
    }

   
}
