using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

        public GameObject menu;
        public HUD HUD;
        

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
            if (HUD.dead)
            {
            Time.timeScale = 0;
            menu.SetActive(true);
            }
        }
}
