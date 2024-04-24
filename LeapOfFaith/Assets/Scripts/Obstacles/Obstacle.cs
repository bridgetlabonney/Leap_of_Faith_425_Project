using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    public int dmg;
    public int type;
    public bool hurt;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //init type of obstacle
        switch (type)
        {
            case 0: //default: 0 dmg log (needs to be jumped over)
                dmg = 0;
                //load asset
                break;
            case 1: //spike
                dmg = 1;
                //load asset
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hurt && collision.tag == "Player")
        {
            player.health = player.health - dmg;
            StartCoroutine(iframes());
        }
        
    }

    IEnumerator iframes()
    {
        hurt = true;
        player.GetComponent<Animator>().SetBool("takeHit", true);
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Animator>().SetBool("takeHit", false);
        hurt = false;
    }
}
