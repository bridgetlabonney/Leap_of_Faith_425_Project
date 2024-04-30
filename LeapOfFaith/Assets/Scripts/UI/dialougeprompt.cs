using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialougeprompt : MonoBehaviour
{
   public bool waiting;
   public GameObject prompt;
    private void Start()
    {
        waiting = true;
    }

    private void Update()
    {
        if (!waiting)
        {
            prompt.SetActive(true);
        }
        else prompt.SetActive(false);
    }
}
