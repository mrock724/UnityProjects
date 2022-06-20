using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int potency = 1;

    public AudioClip pickupClip;

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Object that entered the trigger : " + other);

        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            //controller.ChangeHealth(1);
            //Destroy(gameObject);
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(potency);
                controller.PlaySound(pickupClip);
                Destroy(gameObject);

                //controller.PlaySound(pickupClip);
            }
        }
    }
}
