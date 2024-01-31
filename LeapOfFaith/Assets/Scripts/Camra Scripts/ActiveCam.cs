using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActiveCam : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera activeCamera = null;

    public void setActiveCam(CinemachineVirtualCamera cam)
    {
        activeCamera = cam;
    }
    public void diableActiveCam()
    {
        activeCamera.Priority = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
