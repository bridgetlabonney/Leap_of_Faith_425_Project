using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsFirstButton;
    public GameObject mainMenuFirstButton;
    public GameObject optionsButton;
    public GameObject backButton;
    public bool isOptionsActive = false;
    public bool isMainMenuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!optionsButton.activeInHierarchy && !isOptionsActive)
        {
            isOptionsActive = true;
            isMainMenuActive = false;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsFirstButton);
        }

        if (!backButton.activeInHierarchy && !isMainMenuActive)
        {
            isMainMenuActive = true;
            isOptionsActive = false;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsButton);
        }



    }
}
