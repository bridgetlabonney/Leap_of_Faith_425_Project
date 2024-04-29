using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
   
    [SerializeField] Button button;
    [SerializeField] int dif;

    public void Start()
    {
        
    }
    public void setdifficulty()
    {
        PlayerPrefs.SetInt("lightRadius", dif);
        //button.interactable = false;
        Debug.Log(PlayerPrefs.GetInt("lightRadius", 3));

        
    }

    
    public void Update()
    {
        if (dif != PlayerPrefs.GetInt("lightRadius", 3))
        {
            button.interactable = true;
        }
        //else button.interactable = false;

    }




}
