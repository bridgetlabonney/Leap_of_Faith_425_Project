using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject fireball;
    public GameObject bigFireball;
    public GameObject fallingPlatform;
    public Transform slamStart;
    public Transform fireballPos;
    public Transform bigFireballPos;
    public float health = 3f;
    private Animator animations;
    private bool canFireball = true;
    private bool isInvuln = false;
    public int timesShot = 0;
    public int timesShotBig = 0;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    Coroutine co;

    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    public Transform position5;
    public Transform position6;


    private float timer;

    [SerializeField] private Transform vulnerableSpot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2 && canFireball)
        {
            timer = 0;
            shoot();
            timesShot += 1;
        }

        if(health <= 0f)
        {
            animations.SetTrigger("Death");
            StartCoroutine(Death());
        }

        if(timesShot >= 1 && timesShot % 5 == 0)
        {
            timesShot = 0;
            animations.SetTrigger("Attack");
            StartCoroutine(BigFireball());
        }

        if(timesShotBig >= 3 && canFireball)
        {
            animations.SetTrigger("GroundSlam");
            StartCoroutine(GroundSlam());
        }
    }

    void shoot()
    {
        if(canFireball)
        {
            Instantiate(fireball, fireballPos.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isInvuln)
        {
            health -= 1f;
            StartCoroutine(InvulnHit());
        }
    }

    IEnumerator GroundSlam()
    {
        canFireball = false;
        isInvuln = true;
        boxCollider.size = new Vector2(0.24f, 0.9f);
        this.transform.position = new Vector3(slamStart.transform.position.x, slamStart.transform.position.y, slamStart.transform.position.z);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(55, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(-55, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(23, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(0, 0);
        this.transform.position = new Vector3(slamStart.transform.position.x, slamStart.transform.position.y, slamStart.transform.position.z);
        boxCollider.size = new Vector2(0.83f, 0.9f);
        isInvuln = false;
        co = StartCoroutine(StartFallingPlatforms());
    }

    IEnumerator InvulnHit()
    {
        canFireball = false;
        isInvuln = true;
        animations.SetTrigger("IdleNoAttackDamage");
        StopCoroutine(co);
        for(int i = 0; i < 14; i++)
        {
            fallingPlatform = GameObject.FindGameObjectWithTag("FallingSpike");
            Destroy(fallingPlatform);
            yield return new WaitForSeconds(0.0001f);
        }
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        this.transform.position = new Vector3(slamStart.transform.position.x, slamStart.transform.position.y, slamStart.transform.position.z);
        yield return new WaitForSeconds(2);
        animations.SetTrigger("IdleNoAttackTimeUp");
        canFireball = true;
        isInvuln = false;
    }

    IEnumerator Death()
    {
        canFireball = false;
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    IEnumerator BigFireball()
    {
        canFireball = false;
        Instantiate(bigFireball, bigFireballPos.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        timer = 0;
        animations.SetTrigger("DoneAttacking");
        canFireball = true;
        timesShotBig += 1;
    }

    IEnumerator StartFallingPlatforms()
    {
        canFireball = false;
        animations.SetTrigger("GroundSlamDone");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(fallingPlatform, position1.position, Quaternion.identity);
            Instantiate(fallingPlatform, position6.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform, position3.position, Quaternion.identity);
            Instantiate(fallingPlatform, position4.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
        }
        yield return new WaitForSeconds(5);
        animations.SetTrigger("IdleNoAttackTimeUp");

    }
}
