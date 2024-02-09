using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EscMenu : MonoBehaviour
{

   public GameObject menu;
    public bool menuEnabled = false;
   
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
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            menuEnabled = !menuEnabled;
            if (!menuEnabled)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(false);
                
            }
            
        }
    }

    

}
