using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera activeCamera;

    public void setActiveCam(Camera cam)
    {
        activeCamera = cam;
    }
    public void diableActiveCam()
    {
        activeCamera.enabled = !activeCamera.enabled;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
