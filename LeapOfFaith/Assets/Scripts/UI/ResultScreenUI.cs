using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text timerText;
    public GameObject menu;

    public void loadScreen()
    {
        menu.SetActive(true);
    }
}
