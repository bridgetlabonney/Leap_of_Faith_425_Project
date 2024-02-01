using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO
//press button to access dialogue? prolly a diff script
//fix timing on typewriter
//wait for delay, then display button animation for continuing (ienum?)

//works for now. good enough to write opening cutscene!
public class DialogueBox : MonoBehaviour
{
    [TextAreaAttribute] public string[] words;
    
    public Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displaywords(words));
    }

    //types the words in a "typewriter" like fashion
    //used a solution from https://gamedevbeginner.com/dialogue-systems-in-unity/ with minor tweaks
    //thanks John!
    IEnumerator typewriter(string t)
    {

            
              string holder = null;
              foreach(char c in t)
              {
                  holder += c;
                yield return new WaitForSeconds(3 / 4);
                dialogue.text = holder;
                yield return new WaitForSeconds(3 / 4);

              }

        }

    //displays each dialogue box
    IEnumerator displaywords(string[] words)
    {
        foreach (string t in words)
        {
            StartCoroutine(typewriter(t));
            yield return new WaitUntil(() => Input.anyKeyDown == true);
            yield return new WaitForSeconds(3/4); //prevents ignoring next input
        }
        
    }
}