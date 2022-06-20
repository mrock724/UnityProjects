using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody2D;

    public bool vertical;

    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    Animator animator;

    bool broken = true;

    public int damageAmt = -1;

    public ParticleSystem smokeFX;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        timer = changeTime;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 position = rigidbody2D.position;
        //position.x = position.x + Time.deltaTime * speed;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed;
        }
        rigidbody2D.MovePosition(position);
        */

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        //remember ! inverse the test, so if broken is true !broken will be false and return won�t be executed.
        if (!broken)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;

            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;

            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);

        if (!broken)
        {
            return;
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(damageAmt);
        }
    }
    */

    void OnCollisionStay2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(damageAmt);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        animator.SetTrigger("Fixed");

        smokeFX.Stop();
    }
}