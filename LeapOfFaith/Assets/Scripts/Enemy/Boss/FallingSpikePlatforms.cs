using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikePlatforms : MonoBehaviour
{


    public float force;
    private Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, -1).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 11.0)
        {
            Destroy(gameObject);
        }
    }
}
