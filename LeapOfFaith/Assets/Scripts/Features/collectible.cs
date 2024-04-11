using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour { 

    public int point_value;
    public CollectibleManager cm;
    public AudioSource pickup;
    
    
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
        this.gameObject.SetActive(false);
    }
}
