using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

        public GameObject menu;
        public HUD HUD;
        public bool menuEnabled = false;
        public checkpointManager check;

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
            if (HUD.checkDeath())
            {
                menuEnabled = !menuEnabled;
                if (!menuEnabled)
                {
                    Time.timeScale = 0;
                    menu.SetActive(true);

                }
                else
                {
                    Time.timeScale = 1;
                    menu.SetActive(false);

                }

            }
        }
}
