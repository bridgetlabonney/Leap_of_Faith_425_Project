using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPrompt : MonoBehaviour
{
    //On collision, tutorial pops up
    public GameObject prompt; //collection of animated images/text that is DISABLED in the editor
    //ALL PROMPTS LIVE ON THE SAME CANVAS as a COLLECTION OF OBJECTS FOR EACH
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false); //failsafe
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
    }
}
