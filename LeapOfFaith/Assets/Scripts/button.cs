using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] private GameObject door;
    AudioSource sound;
    //Animator anim;
    bool switched = false;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && switched == false)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                switched = true;
                door.SetActive(false);
                sound.Play();


            }
            if (col.CompareTag("Player") && switched == true)
            {
                if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
                {
                    switched = true;
                    door.SetActive(false);
                    sound.Play();
                }
            }
        }
    }
}