using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject destination;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("tag succesful");
            //grab position of destination
            Vector3 des = destination.transform.position;
            StartCoroutine(Teleport(des));
            //set position of player to position of destination

        }
    }
    IEnumerator Teleport(Vector3 des)
    {
        Debug.Log("Coroutine");
        Player.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        Player.transform.position = des + offset; //Position of destination
        yield return new WaitForSeconds(0.01f);
        Player.SetActive(true);
    }
}
