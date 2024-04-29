using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Goal g;
    int cscore; //collectible
    int score;
    public bool timerOn;
    int jumps;
    private float timer;
    public ResultScreenUI menu; //result screen
    void Start()
    {
        timer = 0;
        score = 0;
        timerOn = true;
        cscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime; //since the game is time=0 in the pause menu this SHOULDNT need any extra hookups.
        }
        //add time to the timer
        if(g.hit) //check for the goal getting hit
        {
            loadTotals(); //load result screen
            g.hit = false;
        }

    }

    public void addCScore(int value)
    {
        cscore += value;
    }

    public void addJScore()
    {
        jumps++;
    }

    void loadTotals()
    {

        timerOn = false;
        //calculate final score
        score = ((cscore * 100) + 100) - jumps;
        //convert timer into a more readable thing
        //this code was ripped from: https://www.gamedev.net/forums/topic/702432-unity-how-to-make-a-ui-timer-beginners-guide-c-script/
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        //end of ripped code
        //load into UI
        string secondsString;
        if(seconds < 10)
        {
           secondsString = "0" + seconds.ToString();
        }
        else { secondsString = seconds.ToString(); }
        //technically also ripped from https://www.gamedev.net/forums/topic/702432-unity-how-to-make-a-ui-timer-beginners-guide-c-script/
        //but modified so it actually displays correctly
        menu.timerText.text += minutes.ToString() + ":" + secondsString;
        menu.scoreText.text += score.ToString();
        //end of second rip
        menu.loadScreen();
    }
}
