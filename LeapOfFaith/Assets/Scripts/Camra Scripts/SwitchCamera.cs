using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraManager cm;
    [SerializeField] private int whichCamera;
    void Start()
    {
        cm = GameObject.Find("ActiveCameraListner").GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cm.resetCameras();
            cm.setMainCam(whichCamera);
        }
    }
}
