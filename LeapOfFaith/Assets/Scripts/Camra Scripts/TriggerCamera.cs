using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera thisCamera;
    [SerializeField] GameObject cameraListener;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        print("TriggerEnter");
       if(collision.gameObject.CompareTag("Player"))
        {
            /* thisCamera.enabled = !thisCamera.enabled;
             cameraListener.GetComponent<ActiveCam>().diableActiveCam();
             cameraListener.GetComponent<ActiveCam>().setActiveCam(thisCamera);
            // cameraListener.ActiveCam.disableActiveCam();
             //cameraListener.ActiveCam.setActiveCam(thisCamera);
            */ //will use Cinemachine scripts for this. For now it is disabled
            if (cameraListener.GetComponent<ActiveCam>() != thisCamera)
            {
                Debug.Log("Switch camera");
                thisCamera.Priority = 10;
                cameraListener.GetComponent<ActiveCam>().diableActiveCam();
                cameraListener.GetComponent<ActiveCam>().setActiveCam(thisCamera);
            }
        }
    }
}
