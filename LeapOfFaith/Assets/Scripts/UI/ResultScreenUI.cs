using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResultScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text timerText;
    public GameObject menu;

    public GameObject resultsFirstButton;

    public void loadScreen()
    {
        menu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(resultsFirstButton);
    }
}
