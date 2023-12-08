using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUD : MonoBehaviour
{
    //controls health bar
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public Player player;
    public Sprite half;
    public Sprite empty;
    // Start is called before the first frame update
    void Start()
    {
       // h1.GetComponent<UnityEngine.UI.Image>().sprite
    }

    // Update is called once per frame
    void Update()
    {
        //check for new updates to player values
        healthConfig(player.health);
       
    }

    void healthConfig(int health)
    {
        switch (health)
        {

            case 0:
                break;

            case 1:
                h1.GetComponent<UnityEngine.UI.Image>().sprite = half;
                h2.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                h3.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                break;
            case 2:
                //h1.GetComponent<UnityEngine.UI.Image>().sprite = full;
                h2.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                h3.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                break;
            case 3:
               // h1.GetComponent<UnityEngine.UI.Image>().sprite = full;
                h2.GetComponent<UnityEngine.UI.Image>().sprite = half;
                h3.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                break;
            case 4:
                //h1.GetComponent<UnityEngine.UI.Image>().sprite = full;
                //h2.GetComponent<UnityEngine.UI.Image>().sprite = full;
                h3.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                break;
            case 5:
                
                h3.GetComponent<UnityEngine.UI.Image>().sprite = half;
                break;
            default:
                break;

        }
    }
}
