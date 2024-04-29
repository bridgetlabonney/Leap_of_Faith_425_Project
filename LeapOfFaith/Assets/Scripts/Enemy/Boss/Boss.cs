using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject fireball;
    public GameObject bigFireball;
    public GameObject fallingPlatform;
    public GameObject fallingPlatform2;
    public GameObject fallingPlatform3;
    public GameObject goal;
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

        if(health == 3f) //phase 1
        {
            if (timer > 2 && canFireball)
            {
                timer = 0;
                shoot();
                timesShot += 1;
            }


            if (timesShot >= 1 && timesShot % 5 == 0)
            {
                timesShot = 0;
                animations.SetTrigger("Attack");
                StartCoroutine(BigFireball());
            }

            if (timesShotBig >= 3 && canFireball)
            {
                timesShot = 0;
                timesShotBig = 0;
                animations.SetTrigger("GroundSlam");
                StartCoroutine(GroundSlam());
            }
        }

        if(health == 2f) //phase 2
        {
            if (timer > 1.5f && canFireball)
            {
                timer = 0;
                shoot();
                timesShot += 1;
            }


            if (timesShot >= 1 && timesShot % 7 == 0)
            {
                timesShot = 0;
                animations.SetTrigger("Attack");
                StartCoroutine(BigFireball());
            }

            if (timesShotBig >= 3 && canFireball)
            {
                timesShot = 0;
                timesShotBig = 0;
                animations.SetTrigger("GroundSlam");
                StartCoroutine(GroundSlamP2());
            }
        }

        if (health == 1f) //phase 3
        {
            if (timer > 1f && canFireball)
            {
                timer = 0;
                shoot();
                timesShot += 1;
            }


            if (timesShot >= 1 && timesShot % 10 == 0)
            {
                timesShot = 0;
                animations.SetTrigger("Attack");
                StartCoroutine(BigFireball());
            }

            if (timesShotBig >= 3 && canFireball)
            {
                timesShot = 0;
                timesShotBig = 0;
                animations.SetTrigger("GroundSlam");
                StartCoroutine(GroundSlamP3());
            }
        }

        if (health <= 0f && canFireball) //dead
        {
            animations.SetTrigger("Death");
            StartCoroutine(Death());
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
            canFireball = false;
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

    IEnumerator GroundSlamP2()
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
        co = StartCoroutine(StartFallingPlatformsP2());
    }

    IEnumerator GroundSlamP3()
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
        co = StartCoroutine(StartFallingPlatformsP3());
    }

    IEnumerator InvulnHit()
    {
        isInvuln = true;
        boxCollider.size = new Vector2(0.0f, 0.0f);
        animations.SetTrigger("IdleNoAttackDamage");
        StopCoroutine(co);
        for(int i = 0; i < 14; i++)
        {
            fallingPlatform = GameObject.FindGameObjectWithTag("FallingSpike");
            Destroy(fallingPlatform);
            yield return new WaitForSeconds(0.0001f);
        }
        yield return new WaitForSeconds(1.5f);
        rb.velocity = new Vector3(0, 0, 0);
        this.transform.position = new Vector3(slamStart.transform.position.x, slamStart.transform.position.y, slamStart.transform.position.z);
        yield return new WaitForSeconds(1.5f);
        boxCollider.size = new Vector2(0.83f, 0.9f);
        animations.SetTrigger("IdleNoAttackTimeUp");
        canFireball = true;
        isInvuln = false;
        timer = 0;
    }

    IEnumerator Death()
    {
        canFireball = false;
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        goal.SetActive(true);
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
        canFireball = true;

    }

    IEnumerator StartFallingPlatformsP2()
    {
        canFireball = false;
        animations.SetTrigger("GroundSlamDone");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(fallingPlatform2, position1.position, Quaternion.identity);
            Instantiate(fallingPlatform2, position6.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform2, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform2, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform2, position3.position, Quaternion.identity);
            Instantiate(fallingPlatform2, position4.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform2, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform2, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
        }
        yield return new WaitForSeconds(5);
        animations.SetTrigger("IdleNoAttackTimeUp");
        canFireball = true;

    }

    IEnumerator StartFallingPlatformsP3()
    {
        canFireball = false;
        animations.SetTrigger("GroundSlamDone");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(fallingPlatform3, position1.position, Quaternion.identity);
            Instantiate(fallingPlatform3, position6.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform3, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform3, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform3, position3.position, Quaternion.identity);
            Instantiate(fallingPlatform3, position4.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
            Instantiate(fallingPlatform3, position2.position, Quaternion.identity);
            Instantiate(fallingPlatform3, position5.position, Quaternion.identity);
            yield return new WaitForSeconds(1.667f);
        }
        yield return new WaitForSeconds(5);
        animations.SetTrigger("IdleNoAttackTimeUp");
        canFireball = true;

    }
}
