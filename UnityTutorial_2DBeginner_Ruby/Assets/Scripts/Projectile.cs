using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    //public float maxDist = 1000.0f;

    public float changeTime = 1.0f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.magnitude > maxDist)
        {
            Destroy(gameObject);
        }
        */

        timer -= 4.0f * Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        timer = changeTime;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //we also add a debug log to know what the projectile touch
        /*
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
        */

        EnemyCon e = other.collider.GetComponent<EnemyCon>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
