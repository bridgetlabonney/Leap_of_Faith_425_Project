using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject Point1A;
    public GameObject Point1B;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = Point1B.transform;
        anim.SetBool("Moving", true);
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == Point1B.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 5.5f && currentPoint == Point1B.transform)
        {
            flip();
            currentPoint = Point1A.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 5.5f && currentPoint == Point1A.transform)
        {
            flip();
            currentPoint = Point1B.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Point1A.transform.position, 5.5f);
        Gizmos.DrawWireSphere(Point1B.transform.position, 5.5f);
    }
}
