using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TODO
//press button to access dialogue? prolly a diff script
//fix timing on typewriter
//wait for delay, then display button animation for continuing (ienum?)

//works for now. good enough to write opening cutscene!
public class DialogueBox : MonoBehaviour
{
    public Dialogue d;
    public dialougeprompt pmt;
    public Text dialogue;
    private int txtcnt = 0;
    public bool SceneChange;
    public string scene;
    public bool Tutorial;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displaywords(d.words));
    }

    //types the words in a "typewriter" like fashion
    //used a solution from https://gamedevbeginner.com/dialogue-systems-in-unity/ with minor tweaks
    //thanks John!

    void Update()
    {
        if (Tutorial)
        {
            if (txtcnt == d.words.Length && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
            {
                box.SetActive(false);
            }
        }
        else
        {
            if (txtcnt == d.words.Length && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
            {
                if (SceneChange)
                {
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    box.SetActive(false);
                }
            }
        }
    }

    void changeDialogue(Dialogue newWords)
    {
       
        d = newWords;
    }
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
        pmt.waiting = false;

    }

    //displays each dialogue box
    IEnumerator displaywords(string[] words)
    {
        
        foreach (string t in words)
        {
            txtcnt++;
            pmt.waiting = true;
            StartCoroutine(typewriter(t));
            if (!Tutorial)
            {
                
                yield return new WaitUntil(() => (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")));
                
            }
            else
            {
                yield return new WaitUntil(() => (Input.GetMouseButtonDown(0) == true || Input.GetButtonDown("Jump") == true));
            }
            yield return new WaitForSeconds(3/4); //prevents ignoring next input, for some reason
        }
        
    }
}
