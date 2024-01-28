using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera thisCamera;
    [SerializeField] GameObject cameraListener;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
           /* thisCamera.enabled = !thisCamera.enabled;
            cameraListener.GetComponent<ActiveCam>().diableActiveCam();
            cameraListener.GetComponent<ActiveCam>().setActiveCam(thisCamera);
           // cameraListener.ActiveCam.disableActiveCam();
            //cameraListener.ActiveCam.setActiveCam(thisCamera);
           */ //will use Cinemachine scripts for this. For now it is disabled


        }
    }
}
