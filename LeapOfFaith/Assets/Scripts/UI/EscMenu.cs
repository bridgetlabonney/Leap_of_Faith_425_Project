using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EscMenu : MonoBehaviour
{

    public GameObject menu;
    public bool menuEnabled = false;
    public HUD HUD;

    public GameObject escFirstButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    

    void toggleMenu()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.JoystickButton7)) && !HUD.dead)
        {
            menuEnabled = !menuEnabled;
            if (!menuEnabled)
            {
                Time.timeScale = 0;
                menu.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(escFirstButton);
            }
            else
            {
                Time.timeScale = 1;
                menu.SetActive(false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        toggleMenu();
    }

}

