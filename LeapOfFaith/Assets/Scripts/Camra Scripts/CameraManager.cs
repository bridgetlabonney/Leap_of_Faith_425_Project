using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] cameras;

    public void resetCameras()
    {
        foreach (var n in cameras)
        {
            n.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        }
    }

    public void setMainCam(int cam)
    {
        cameras[cam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }
}
