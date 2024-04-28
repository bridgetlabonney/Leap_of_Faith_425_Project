using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireball : MonoBehaviour
{
    private GameObject boss;
    private GameObject player;
    private GameObject Wall;
    private GameObject Ground;
    private Rigidbody2D rb;
    public float force = 8;
    private float timer;
    Vector2 temp;
    float bosstemp;
    private bool canGrow = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Wall = GameObject.FindGameObjectWithTag("Ground");
        Ground = GameObject.FindGameObjectWithTag("WallLayer");
        boss = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(canGrow)
        {
            transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y + 2, 0);
            temp = transform.localScale;
            temp.x += Time.deltaTime * 6;
            temp.y += Time.deltaTime * 6;

            transform.localScale = temp;
        }

        if(temp.x >= 24)
        {
            canGrow = false;

            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x * 0.01f, direction.y * 0.01f).normalized * force;

            float rot = Mathf.Atan2(-direction.y * 0.01f, -direction.x * 0.01f) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().health -= 3;
        }
        else if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("WallLayer"))
        {
            Destroy(gameObject);
        }
    }

}
