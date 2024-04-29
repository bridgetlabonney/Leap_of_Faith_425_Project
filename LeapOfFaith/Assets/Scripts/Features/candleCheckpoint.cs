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
    private Animator anim;
    IEnumerator turnLight()
    {
        candle.light_enabled = true;
        anim.SetBool("IsOn", true);
        yield return new WaitForSecondsRealtime(7);
        candle.light_enabled = false;
        anim.SetBool("IsOn", false);
    }

    private void Start()
    {
        checkpointpos = this.transform.position;
        anim = GetComponent<Animator>();
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
            lighton = true;
            anim.SetBool("IsOn", true);
            StartCoroutine(turnLight());
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2)) && lighton == false)
        {
            lighton = true;
            StartCoroutine(turnLight());


        }
        lighton = false;
        //anim.SetBool("IsOn", false);
    }



}
