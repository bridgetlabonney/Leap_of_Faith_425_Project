using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_In_World : MonoBehaviour
{
    [SerializeField] private GameObject door;
    AudioSource sound;
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
        print("Entered trigger");
        if (col.CompareTag("Player"))
        {
            print("tag succesful");
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("Key down");
                door.SetActive(false);
                sound.Play();
                
            }
        }
    }
}