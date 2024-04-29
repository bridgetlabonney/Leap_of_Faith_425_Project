using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{

        public GameObject menu;
        public HUD HUD;

    public GameObject gameoverFirstButton;


    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
        void Update()
        {
            toggleMenu();
        }

        void toggleMenu()
        {
            if (HUD.dead && Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menu.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(gameoverFirstButton);
            }
        }
}
