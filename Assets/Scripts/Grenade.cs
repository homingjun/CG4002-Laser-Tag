using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 3f;
    public float force = 300f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;
    public bool hasThrown = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasThrown)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0f && !hasExploded && hasThrown)
        {
            Explode();
        }
    }

    void Explode()
    {
        //Explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        /*Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }*/

        Destroy(gameObject);
    }
}
