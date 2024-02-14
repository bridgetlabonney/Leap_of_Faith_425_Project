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
    public checkpointManager c;
    IEnumerator turnLight()
    {
        candle.light_enabled = true;
        yield return new WaitForSecondsRealtime(7);
        candle.light_enabled = false;
    }

    

    private void Update()
    {
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!crossed)
        {
            crossed = true;
            c.checkpoint(checkpointpos);
        }

        if (Input.GetKeyDown(KeyCode.F) && lighton == false)
        {
            lighton = true;
            StartCoroutine(turnLight());
           

        }
        lighton = false;
    }

    public void Respawn()
    {

    }


}
