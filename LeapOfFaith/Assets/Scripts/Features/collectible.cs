using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieMarc.Darkness;

public class collectible : MonoBehaviour { 

    public int point_value;
    public CollectibleManager cm;
    public AudioSource pickup;
    public LightEmit light;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cm.addScore(point_value);
        pickup.Play();
        light.light_enabled = false; //apparently the light will still be there even if you disable the game object???
        this.gameObject.SetActive(false);
    }
}
